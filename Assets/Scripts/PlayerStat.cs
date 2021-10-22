using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] float _maxDodgeGage;

    public float _nowDodgeGage { get; private set; }
    public void SetDodgeCool() => _nowDodgeGage -= 1;
    public bool _isDodgeOk { get { return _nowDodgeGage >= 1 ? true : false; } }

    public bool _isNodamage { get; set; }

    private void Awake()
    {
        _isNodamage = false;
        _nowDodgeGage = _maxDodgeGage;
    }

    void Update()
    {
        _nowDodgeGage = Mathf.Min(_maxDodgeGage, _nowDodgeGage + Time.deltaTime);
    }
}
