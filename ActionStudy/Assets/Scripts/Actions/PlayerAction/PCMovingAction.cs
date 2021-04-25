using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CustomPhysics;

public class PCMovingAction : BaseAction
{
    [SerializeField] PlayerInputKey _controller;
    [SerializeField] PlayerStat _stat;

    [Header("Action Data")]
    [SerializeField] float _runAniSpeed;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _rotSpeed;
    [SerializeField] LayerMask _wall;

    [Header("Resources")]
    [SerializeField] AudioSource _sfx;
    [SerializeField] AudioClip[] _clip;

    public override void ChangeAction()
    {
        if (!_controller.IsMoving)
            _owner.ChangeAction("Idle");
        if (_stat._isDodgeOk && _controller.IsDodge)
            _owner.ChangeAction("Dodge");
        if (_controller.IsAtk1) _owner.ChangeAction("Atk");
    }

    public override void UpdateAction()
    {
        ChangeAction();
        Moving();
        _animator.SetFloat("Moving", Mathf.Min(1, _animator.GetFloat("Moving") + _runAniSpeed * Time.deltaTime));
    }

    void Moving()
    {
        PlayerManager pm = _owner as PlayerManager;

        Vector3 moveDis = pm.Cam.transform.rotation * new Vector3(_controller.widthMoving, 0, _controller.verticalMoving);
        moveDis.y = 0;

        //_owner.transform.position += moveDis.normalized * Time.deltaTime * _moveSpeed;
        _owner.transform.position = FixedMoveVector(_owner.transform.position, moveDis.normalized * Time.deltaTime * _moveSpeed, _wall);
        _animator.transform.rotation = Quaternion.Slerp(_animator.transform.rotation, Quaternion.LookRotation(moveDis.normalized), Time.deltaTime * _rotSpeed);
    }

    public void PlayFootstep()
    {
        _sfx.clip = _clip[Random.Range(0, _clip.Length - 1)];
        _sfx.Play();
    }
}
