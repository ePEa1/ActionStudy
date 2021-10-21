using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ActorController;

public class PlayerManager : CharacterManager
{
    [SerializeField] Camera _cam;
    [SerializeField] PlayerHPBar _hpBar;

    public Camera Cam { get { return _cam; } }

    private void Awake()
    {
        base.Awake();
        _hpBar.Setting(_maxHp);
    }

    protected void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.U))
            _nowHp = Mathf.Max(0, _nowHp - 5);
    }

    protected override void ChangeHp(float hp)
    {
        base.ChangeHp(hp);
        _hpBar.UpdateHpBar(hp);
    }

    #region Actor Actions
    public override void MovingCheck(Vector3 moveDir) => _nowAction.CheckMoveDir(moveDir);

    public override void OnNormalAtk(InputState state) => _nowAction.CheckInputKeys(InputKey.NORMALATK, state);

    public override void OnDodge(InputState state) => _nowAction.CheckInputKeys(InputKey.DODGE, state);
    #endregion
}
