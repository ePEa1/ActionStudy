using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AtkEffData", menuName = "Custom Data Asset/Attack Effect Data", order = int.MaxValue)]
public class AtkEffDataAsset : ScriptableObject
{
    public AtkEffData[] _effDatas;
}

[System.Serializable]
public class AtkEffData
{
    public GameObject _effObject;
    public float _spawnTiming = 0.0f;
    public bool _isChildren = false;
    public Vector3 _position;
    public Vector3 _angle;
}