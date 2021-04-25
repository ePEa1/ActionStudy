using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] float _dodgeCool;

    public float _nowDodgeCool { get; private set; }
    public void SetDodgeCool() => _nowDodgeCool = _dodgeCool;
    public bool _isDodgeOk { get { return _nowDodgeCool == 0 ? true : false; } }

    public bool _isNodamage { get; set; }

    private void Awake()
    {
        _isNodamage = false;
        _nowDodgeCool = 0.0f;
    }

    void Update()
    {
        _nowDodgeCool = Mathf.Max(0, _nowDodgeCool - Time.deltaTime);
    }
}
