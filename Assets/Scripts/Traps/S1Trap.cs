using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1Trap : MonoBehaviour
{
    [SerializeField] Transform[] _traps;
    [SerializeField] float _moveSpeed;
    void Update()
    {
        foreach(Transform trap in _traps)
        {
            trap.position += Vector3.left * _moveSpeed * Time.deltaTime;
            if (trap.position.x < 1.5f)
                trap.position = new Vector3(45.0f, trap.position.y, trap.position.z);
        }
    }
}
