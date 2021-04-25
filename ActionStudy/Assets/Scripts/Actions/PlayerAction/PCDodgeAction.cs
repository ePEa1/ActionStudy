using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CustomPhysics;

public class PCDodgeAction : BaseAction
{
    [SerializeField] PlayerInputKey _controller;
    [SerializeField] PlayerStat _stat;
    [SerializeField] AudioSource _sfx;
    [SerializeField] LayerMask _wall;

    [Header("Action Data")]
    [SerializeField] float _dodgePow;
    [SerializeField] AnimationCurve _dodgeAC;
    [SerializeField] float _dodgeSpeed;

    float _time = 0.0f;
    float _beforeTime = 0.0f;
    Vector3 _dodgeDir;

    bool _getInput = false;

    public override void ChangeAction() { }

    public override void UpdateAction()
    {
        PlayDodge();
    }

    public override void StartAction()
    {
        _getInput = false;
        _time = 0.0f;
        _beforeTime = 0.0f;

        _stat.SetDodgeCool();
        SetDodgeAnim();
        
        SetDodgeData();

        _sfx.Play();
    }

    public override void EndAction()
    {
        _animator.SetBool("IsDodge", false);
    }

    public void FinishDodge()
    {
        if (_controller.IsMoving)
            _owner.ChangeAction("Moving");
        else
            _owner.ChangeAction("Idle");
    }

    public void GetInput() => _getInput = true;

    void SetDodgeAnim()
    {
        _animator.SetTrigger("Dodge");
        _animator.SetBool("IsDodge", true);

        PlayerManager pm = _owner as PlayerManager;

        Vector3 dir = new Vector3(_controller.widthMoving, 0, _controller.verticalMoving);
        dir = pm.Cam.transform.rotation * dir;
        dir.y = 0;
        _animator.transform.rotation = Quaternion.LookRotation(dir.normalized);
    }

    void SetDodgeData()
    {
        PlayerManager pm = _owner as PlayerManager;

        _dodgeDir = new Vector3(_controller.widthMoving, 0, _controller.verticalMoving).normalized;
        _dodgeDir = pm.Cam.transform.rotation * _dodgeDir;
        _dodgeDir.y = 0;
    }

    void PlayDodge()
    {
        _time += Time.deltaTime * _dodgeSpeed;
        float pow = (_dodgeAC.Evaluate(_time) - _dodgeAC.Evaluate(_beforeTime)) * _dodgePow;
        _owner.transform.position = FixedMoveVector(_owner.transform.position, _dodgeDir * pow, _wall);
        _beforeTime = _time;
    }    
}
