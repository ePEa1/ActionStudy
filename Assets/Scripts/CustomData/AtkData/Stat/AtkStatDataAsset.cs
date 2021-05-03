using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="AtkStatData", menuName = "Custom Data Asset/Attack Stat Data", order = int.MaxValue)]
public class AtkStatDataAsset : ScriptableObject
{
    [Header("Moving Data")]
    public float _moveRange;
    public float _moveSpeed;
    public AnimationCurve _moveCurve;

    [Header("Damage Data")]
    public DamageData[] _damDatas;
}

[System.Serializable]
public class DamageData
{
    public float _power = 1.0f;
    public Vector3 _atkCenter = Vector3.zero;
    public Vector3 _atkRange = Vector3.one;
    public float _hitTiming = 0.0f;
    public float _knockPower = 0.0f;
}