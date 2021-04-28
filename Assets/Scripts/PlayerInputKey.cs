using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputKey : MonoBehaviour
{
    [Header("Moving Key")]
    [SerializeField] KeyCode _go;
    [SerializeField] KeyCode _back;
    [SerializeField] KeyCode _left;
    [SerializeField] KeyCode _right;

    [SerializeField] KeyCode _dodge;
    [SerializeField] KeyCode _atk1;

    public bool IsMoving { get { return widthMoving != 0 || verticalMoving != 0 ? true : false; } }

    public float widthMoving
    { 
        get 
        {
            int a = 0, b = 0;
            if (Input.GetKey(_left)) b = 1;
            if (Input.GetKey(_right)) a = 1;
            return a - b;
        }
    }

    public float verticalMoving
    {
        get
        {
            int a = 0, b = 0;
            if (Input.GetKey(_back)) b = 1;
            if (Input.GetKey(_go)) a = 1;
            return a - b;
        }
    }

    public bool IsDodge { get { return Input.GetKeyDown(_dodge) ? true : false; } }
    public bool IsAtk1 { get { return Input.GetKeyDown(_atk1) ? true : false; } }
}
