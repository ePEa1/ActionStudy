using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _cam;
    [SerializeField] float _followSpeed = 8.0f;
    [SerializeField] float _followDis = 3.0f;
    [SerializeField] float _high = 1.5f;

    [SerializeField] float _rotSpeed = 2.0f;

    [SerializeField] float _xRot = 0.0f;
    [SerializeField] float _yRot = 20.0f;
    [SerializeField] float[] _rotLimit;

    float _x;
    float _y;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _x = _xRot;
        _y = _yRot;
    }

    void Update()
    {
        (Quaternion rot, Vector3 pos) toTarget = FollowTarget();
        transform.position = toTarget.pos;
        transform.rotation = toTarget.rot;

        _cam.localPosition = Vector3.forward * -_followDis;
    }

    (Quaternion rot, Vector3 pos) FollowTarget()
    {
        _x += Input.GetAxis("Mouse X") * _rotSpeed;
        _y += -Input.GetAxis("Mouse Y") * _rotSpeed;

        _y = Mathf.Clamp(_y, _rotLimit[0], _rotLimit[1]);

        Quaternion dir = Quaternion.Euler(_y, _x, 0);
        Vector3 pos = Vector3.Lerp(transform.position, _target.position + Vector3.up * _high, Time.deltaTime * _followSpeed);

        return (dir, pos);
    }
}
