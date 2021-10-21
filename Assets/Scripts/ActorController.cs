using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActorController : MonoBehaviour
{
    public enum InputState
    {
        PRESSED,
        HOLD,
        RELEASED
    };

    public enum InputKey
    {
        NORMALATK,
        DODGE
    };

    [SerializeField] Actor _useActor;

    [Header("Move Key")]
    [SerializeField] KeyCode _left;
    [SerializeField] KeyCode _right;
    [SerializeField] KeyCode _front;
    [SerializeField] KeyCode _back;

    [Header("Action Key")]
    [SerializeField] KeyCode _keyNormalAtk;
    [SerializeField] KeyCode _keyDodge;

    void Update()
    {
        if (_useActor != null)
        {
            CheckMoveDirection();
            CheckActionKey(_keyNormalAtk, _useActor.OnNormalAtk);
            CheckActionKey(_keyDodge, _useActor.OnDodge);
        }
    }

    void CheckMoveDirection()
    {
        int a = 0, b = 0, c = 0, d = 0;

        a = Input.GetKey(_left) ? 1 : 0;
        b = Input.GetKey(_right) ? 1 : 0;
        c = Input.GetKey(_front) ? 1 : 0;
        d = Input.GetKey(_back) ? 1 : 0;

        Vector3 result = new Vector3(b - a, 0.0f, c - d);
        _useActor.MovingCheck(result);
    }

    void CheckActionKey(KeyCode key, Action<InputState> inputAction)
    {
        if (Input.GetKeyDown(key)) inputAction(InputState.PRESSED);
        if (Input.GetKey(key)) inputAction(InputState.HOLD);
        if (Input.GetKeyUp(key)) inputAction(InputState.RELEASED);
    }
}
