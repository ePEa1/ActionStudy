using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCreator : MonoBehaviour
{
    float _time;
    int _count = 0;

    [SerializeField] TimingData[] _data;

    [SerializeField] PoolData[] _objectPools;

    public enum PoolType
    {
        FloorTrap = 0,
        WallTrap = 1
    };

    void Update()
    {
        _time += Time.deltaTime;

        if (_count<_data.Length)
        {
            if (_data[_count]._time <= _time)
            {
                foreach (CreateData data in _data[_count]._traps)
                    CreateTrap(_data[_count], data);
                _count++;
            }
        }
    }

    void CreateTrap(TimingData time, CreateData data)
    {
        Transform obj;
        PoolData pData;
        switch (data._trap)
        {
            case PoolType.FloorTrap:
                pData = _objectPools[(int)PoolType.FloorTrap];
                obj = pData._poolObject.GetChild(pData._count);
                break;

            default:
                pData = _objectPools[(int)PoolType.WallTrap];
                obj = pData._poolObject.GetChild(pData._count);
                break;
        }

        obj.position = data._pos;

        if (data._scale == Vector3.zero)
            obj.localScale = time._scale;
        else
        {
            obj.localScale = data._scale;
            time._scale = data._scale;
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
    [HideInInspector]
    public Vector3 _scale = Vector3.zero;
}

[System.Serializable]
public class CreateData
{
    public TrapCreator.PoolType _trap;
    public Vector3 _pos;
    public Vector3 _scale = Vector3.zero;
}