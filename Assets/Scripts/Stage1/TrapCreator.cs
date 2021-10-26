using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapCreator : MonoBehaviour
{
    float _time;
    int _count = 0;

    [SerializeField] TimingData[] _data;

    [SerializeField] PoolData[] _objectPools;

    public enum PoolType
    {
        FloorTrap = 0,
        RTrap = 1,
        LTrap = 2,
        Event = 3
    };

    void Update()
    {
        _time += Time.deltaTime;

        if (_count<_data.Length)
        {
            if (_data[_count]._time <= _time)
            {
                _data[_count]._event.Invoke();
                foreach (CreateData data in _data[_count]._traps)
                    CreateTrap(_data[_count], data);
                _count++;
            }
        }
    }

    void CreateTrap(TimingData time, CreateData data)
    {
        PoolData pData = _objectPools[(int)data._trap];
        Transform obj = pData._poolObject.GetChild(pData._count);

        if (data._scale == Vector3.zero)
            obj.localScale = time._scale;
        else
        {
            obj.localScale = data._scale;
            time._scale = data._scale;
        }

        if (data._pos == Vector3.zero)
            obj.position = time._pos;
        else
        {
            obj.position = data._pos;
            time._pos = data._pos;
        }

        obj.gameObject.SetActive(true);

        pData._count++;
        if (pData._count >= pData._poolObject.childCount)
            pData._count = 0;
    }
}

[System.Serializable]
public class PoolData
{
    [HideInInspector]
    public int _count = 0;
    public Transform _poolObject;
}

[System.Serializable]
public class TimingData
{
    public float _time;
    public CreateData[] _traps;
    [HideInInspector] public Vector3 _scale = Vector3.zero;
    [HideInInspector] public Vector3 _pos = Vector3.zero;
    public UnityEvent _event;
}

[System.Serializable]
public class CreateData
{
    public TrapCreator.PoolType _trap;
    public Vector3 _pos = Vector3.zero;
    public Vector3 _scale = Vector3.zero;
}