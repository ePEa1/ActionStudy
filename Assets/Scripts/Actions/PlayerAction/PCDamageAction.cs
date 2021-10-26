using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCDamageAction : BaseAction, ITakeDamage
{
    float _knockPow;
    Vector3 _knockDir;

    [Header("Action Data")]
    [SerializeField] float _knockTime;
    [SerializeField] LayerMask _wall;

    float _time = 0;

    string _nextAction = "Idle";

    public void TakeDamage(TakeDamageData data)
    {
        if (!_owner.GetComponent<PlayerStat>()._isNodamage)
        {
            _owner._nowHp = Mathf.Max(0, _owner._nowHp - data._damPow);
            _knockDir = data._knock.normalized;
            _knockPow = Vector3.Distance(Vector3.zero, data._knock);
            _owner.ChangeAction("Damage");
        }
    }

    public override void StartAction()
    {
        _time = 0;
        _animator.SetBool("IsDamage", true);
        _animator.SetTrigger("Damage");
    }

    public override void UpdateAction()
    {
        _animator.transform.rotation = Quaternion.LookRotation(-_knockDir);
        if (_time < _knockTime)
            _owner.transform.position = CustomPhysics.FixedMoveVector(_owner.transform.position, _knockDir * _knockPow * Time.deltaTime, _wall);
        _time += Time.deltaTime;
    }

    public override void CheckInputKeys(ActorController.InputKey key, ActorController.InputState state)
    {
        if (key == ActorController.InputKey.NORMALATK && state == ActorController.InputState.PRESSED)
            _nextAction = "Atk";
        if (key == ActorController.InputKey.DODGE && state == ActorController.InputState.PRESSED)
            _nextAction = "Dodge";
    }

    public override void CheckMoveDir(Vector3 dir)
    {
        if (_nextAction == "Idle")
            _nextAction = "Moving";
    }

    public override void EndAction()
    {
        _animator.ResetTrigger("Damage");
        _animator.SetBool("IsDamage", false);
    }

    public void EndDamage()
    {
        _owner.ChangeAction(_nextAction);
    }
}
