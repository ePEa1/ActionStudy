using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ActorController;

public class PCIdleAction : BaseAction
{
    [SerializeField] PlayerStat _stat;

    [Header("Action Data")]
    [SerializeField] float _stopSpeed;

    public override void UpdateAction()
    {
        _animator.SetFloat("Moving", Mathf.Max(0, _animator.GetFloat("Moving") - _stopSpeed * Time.deltaTime));

    }

    #region Actor Actions
    public override void CheckInputKeys(InputKey key, InputState state)
    {
        if (key == InputKey.NORMALATK && state == InputState.PRESSED)
            _owner.ChangeAction("Atk");

        if (key == InputKey.DODGE && state == InputState.PRESSED && _stat._isDodgeOk)
            _owner.ChangeAction("Dodge");
    }

    public override void CheckMoveDir(Vector3 dir)
    {
        if (dir != Vector3.zero) _owner.ChangeAction("Moving");
    }
    #endregion
}