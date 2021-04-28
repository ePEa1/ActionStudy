using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CustomPhysics;
using static ActorController;

public class PCDodgeAction : BaseAction
{
    [SerializeField] PlayerStat _stat;
    [SerializeField] AudioSource _sfx;
    [SerializeField] LayerMask _wall;

    [Header("Action Data")]
    [SerializeField] float _dodgePow;
    [SerializeField] AnimationCurve _dodgeAC;
    [SerializeField] float _dodgeSpeed;

    Vector3 _dodgeDir = Vector3.zero;

    float _time = 0.0f;
    float _beforeTime = 0.0f;

    bool _finishCheck = false;

    bool _getInput = false;

    public override void UpdateAction()
    {
        PlayDodge();
    }

    public override void StartAction()
    {
        SetDodgeAnim();

        _getInput = false;
        _time = 0.0f;
        _beforeTime = 0.0f;

        _stat.SetDodgeCool();
        _dodgeDir = Vector3.zero;

        _sfx.Play();
    }

    public override void EndAction()
    {
        _animator.SetBool("IsDodge", false);
        _finishCheck = false;
    }

    public override void CheckMoveDir(Vector3 dir)
    {
        if (_finishCheck)
        {
            if (dir == Vector3.zero) _owner.ChangeAction("Idle");
            else _owner.ChangeAction("Moving");
        }

        if (_dodgeDir == Vector3.zero)
        {
            SetDodgeData(dir);
        }
    }

    public void FinishDodge()
    {
        _finishCheck = true;
    }

    public void GetInput() => _getInput = true;

    void SetDodgeAnim()
    {
        _animator.SetTrigger("Dodge");
        _animator.SetBool("IsDodge", true);

        PlayerManager pm = _owner as PlayerManager;
    }

    void SetDodgeData(Vector3 direction)
    {
        PlayerManager pm = _owner as PlayerManager;

        _dodgeDir = new Vector3(direction.x, 0, direction.z).normalized;
        _dodgeDir = pm.Cam.transform.rotation * _dodgeDir;
        _dodgeDir.y = 0;

        _animator.transform.rotation = Quaternion.LookRotation(_dodgeDir.normalized);
    }

    void PlayDodge()
    {
        _time += Time.deltaTime * _dodgeSpeed;
        float pow = (_dodgeAC.Evaluate(_time) - _dodgeAC.Evaluate(_beforeTime)) * _dodgePow;
        _owner.transform.position = FixedMoveVector(_owner.transform.position, _dodgeDir * pow, _wall);
        _beforeTime = _time;
    }    
}
