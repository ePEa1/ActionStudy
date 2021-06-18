using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ActorController;

public class PlayerManager : CharacterManager
{
    [SerializeField] Camera _cam;
    public Camera Cam { get { return _cam; } }

    #region Actor Actions
    public override void MovingCheck(Vector3 moveDir) => _nowAction.CheckMoveDir(moveDir);

    public override void OnNormalAtk(InputState state) => _nowAction.CheckInputKeys(InputKey.NORMALATK, state);

    public override void OnDodge(InputState state) => _nowAction.CheckInputKeys(InputKey.DODGE, state);
    #endregion
}
