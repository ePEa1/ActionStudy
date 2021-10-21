using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActorController;

public class EnemyManager : CharacterManager
{
    public CharacterManager _target { get; protected set; }

    [SerializeField] CharacterManager _startTarget;

    private void OnEnable()
    {
        _target = _startTarget;
    }

    public override void MovingCheck(Vector3 moveDir) => _nowAction.CheckMoveDir(moveDir);

    public override void OnNormalAtk(InputState state)
    {
        if (_nowStat != "Atk")
        _nowAction.CheckInputKeys(InputKey.NORMALATK, state);
    }

    public override void OnDodge(InputState state) => _nowAction.CheckInputKeys(InputKey.DODGE, state);
}