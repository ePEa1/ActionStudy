using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rader : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] bool _startDirection = true;
    [SerializeField] float _distance = 6;
    [SerializeField] float _startPos = 0;

    float _direction;
    Vector3 _startVector;

    void Start()
    {
        _startVector = transform.position;

        if (_startDirection)
            _direction = 1;
        else _direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_startDirection)
        {
            transform.position += new Vector3(_moveSpeed * _direction, 0, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
