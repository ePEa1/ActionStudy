using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAtkAction : BaseAction
{
    [SerializeField] PlayerInputKey _controller;

    bool _isNextAtk = false;
    bool _nextAtkOk = false;

    public override void ChangeAction()
    {
        if (_controller.IsMoving)
            _owner.ChangeAction("Moving");
        else _owner.ChangeAction("Idle");
    }

    public override void UpdateAction()
    {
        CheckAtk1Input();

        if (_controller.IsDodge)
            _owner.ChangeAction("Dodge");
    }

    public override void StartAction()
    {
        PlayAtk();
    }

    public override void EndAction()
    {
        _isNextAtk = false;
        _nextAtkOk = false;
        _animator.SetBool("IsAtk", false);
        _animator.ResetTrigger("Atk");
    }

    void CheckAtk1Input()
    {
        if (_nextAtkOk && _controller.IsAtk1)
        {
            _isNextAtk = true;
        }
    }

    public void SetNextAtk() => _nextAtkOk = true;

    public void CheckNextAtk()
    {
        if (_isNextAtk)
        {
            _isNextAtk = false;
            _nextAtkOk = false;
            PlayAtk();
        }
        else
        {
            ChangeAction();
        }
    }

    void PlayAtk()
    {
        _animator.SetBool("IsAtk", true);
        _animator.SetTrigger("Atk");
    }
}
