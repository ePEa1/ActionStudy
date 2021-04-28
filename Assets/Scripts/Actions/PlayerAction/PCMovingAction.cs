﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CustomPhysics;
using static ActorController;

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

    public override void UpdateAction()
    {
        Moving();
        _animator.SetFloat("Moving", Mathf.Min(1, _animator.GetFloat("Moving") + _runAniSpeed * Time.deltaTime));
    }

    #region Actor Actions
    public override void CheckInputKeys(InputKey key, InputState state)
    {
        if (key == InputKey.DODGE && state == InputState.PRESSED && _stat._isDodgeOk) _owner.ChangeAction("Dodge");
        if (key == InputKey.NORMALATK && state == InputState.PRESSED) _owner.ChangeAction("Atk");
    }

    public override void CheckMoveDir(Vector3 dir)
    {
        if (dir == Vector3.zero)
            _owner.ChangeAction("Idle");
    }
    #endregion

    void Moving()
    {
        PlayerManager pm = _owner as PlayerManager;

        Vector3 moveDis = pm.Cam.transform.rotation * new Vector3(_controller.widthMoving, 0, _controller.verticalMoving);
        moveDis.y = 0;

        _owner.transform.position = FixedMoveVector(_owner.transform.position, moveDis.normalized * Time.deltaTime * _moveSpeed, _wall);
        _animator.transform.rotation = Quaternion.Slerp(_animator.transform.rotation, Quaternion.LookRotation(moveDis.normalized), Time.deltaTime * _rotSpeed);
    }

    public void PlayFootstep()
    {
        _sfx.clip = _clip[Random.Range(0, _clip.Length - 1)];
        _sfx.Play();
        Debug.Log("foot");
    }
}