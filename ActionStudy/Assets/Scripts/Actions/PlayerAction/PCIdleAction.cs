using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCIdleAction : BaseAction
{
    [SerializeField] PlayerInputKey _controller;
    [SerializeField] PlayerStat _stat;

    [Header("Action Data")]
    [SerializeField] float _stopSpeed;

    public override void ChangeAction()
    {
        if (_controller.IsMoving) _owner.ChangeAction("Moving");
        if (_stat._isDodgeOk && _controller.IsDodge)
            _owner.ChangeAction("Dodge");

        if (_controller.IsAtk1) _owner.ChangeAction("Atk");
    }

    public override void UpdateAction()
    {
        _animator.SetFloat("Moving", Mathf.Max(0, _animator.GetFloat("Moving") - _stopSpeed * Time.deltaTime));

        ChangeAction();
    }
}
