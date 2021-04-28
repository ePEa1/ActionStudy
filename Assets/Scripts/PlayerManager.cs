using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ActorController;

public class PlayerManager : CharacterManager
{
    public static PlayerManager playerManager { get; private set; }

    [SerializeField] Camera _cam;
    public Camera Cam { get { return _cam; } }

    #region Actor Actions
    public override void MovingCheck(Vector3 moveDir) => _nowAction.CheckMoveDir(moveDir);

    public override void OnNormalAtk(InputState state) => _nowAction.CheckInputKeys(InputKey.NORMALATK, state);

    public override void OnDodge(InputState state) => _nowAction.CheckInputKeys(InputKey.DODGE, state);
    #endregion

    void Awake()
    {
        if (playerManager != null)
        {
            Destroy(gameObject);
            return;
        }

        playerManager = this;
        ManagerSetup();
    }

    void Update()
    {
        _animator.transform.localPosition = Vector3.zero;
        UpdateAction();
    }

    protected override void ManagerSetup()
    {
        _stats = new Dictionary<string, int>();
        for (int i = 0; i < _statName.Length; i++)
            _stats.Add(_statName[i], i);

        SetAction(_startStat);
    }
}
