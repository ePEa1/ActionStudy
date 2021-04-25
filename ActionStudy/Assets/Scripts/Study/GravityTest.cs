using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTest : MonoBehaviour
{
    float _nowGravity = 0.0f;

    [SerializeField] float _gravityPower = 9.8f;
    [SerializeField] float _jumpPower = 15.0f;
    [SerializeField] LayerMask _wall;

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * _nowGravity;
        _nowGravity += _gravityPower * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
            _nowGravity -= _jumpPower * Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, _nowGravity, _wall))
        {

        }
    }
}
