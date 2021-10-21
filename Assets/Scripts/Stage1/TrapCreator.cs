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
                    CreateTrap(data);
                _count++;
            }
        }
    }

    void CreateTrap(CreateData data)
    {
        Transform obj;
        PoolData pData;
        switch (data._trap)
        {
            case PoolType.FloorTrap:
                pData = _objectPools[(int)PoolType.FloorTrap];
                obj = pData._poolObject.GetChild(pData._count);
                obj.position = data._pos;
                obj.gameObject.SetActive(true);
                break;

            default:
                pData = _objectPools[(int)PoolType.WallTrap];
                obj = pData._poolObject.GetChild(pData._count);
                obj.position = data._pos;
                obj.gameObject.SetActive(true);
                break;
        }

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
}

[System.Serializable]
public class CreateData
{
    public TrapCreator.PoolType _trap;
    public Vector3 _pos; 
}