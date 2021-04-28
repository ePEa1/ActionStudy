using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ActorController;

public class PCAtkAction : BaseAction
{
    [SerializeField] PlayerStat _stat;

    bool _isNextAtk = false;
    bool _nextAtkOk = false;

    bool _finishAtk = false;

    public override void UpdateAction() { }

    public override void StartAction()
    {
        _finishAtk = false;
        PlayAtk();
    }

    public override void EndAction()
    {
        _isNextAtk = false;
        _nextAtkOk = false;
        _finishAtk = false;
        _animator.SetBool("IsAtk", false);
        _animator.ResetTrigger("Atk");
    }

    public override void CheckInputKeys(InputKey key, InputState state)
    {
        //다음 공격 예약
        if (key == InputKey.NORMALATK && state == InputState.PRESSED)
            if (_nextAtkOk && !_isNextAtk) _isNextAtk = true;

        //회피(공격 캔슬 가능)
        if (key == InputKey.DODGE && state == InputState.PRESSED && _stat._isDodgeOk)
            _owner.ChangeAction("Dodge");
    }

    public override void CheckMoveDir(Vector3 dir)
    {
        if (!_isNextAtk && _finishAtk)
        {
            if (dir == Vector3.zero) _owner.ChangeAction("Idle");
            else _owner.ChangeAction("Moving");
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
            _finishAtk = true;
        }
    }

    void PlayAtk()
    {
        _animator.SetBool("IsAtk", true);
        _animator.SetTrigger("Atk");
    }
}
