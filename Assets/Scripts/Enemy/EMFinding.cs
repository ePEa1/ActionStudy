using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMFinding : BaseAction
{
    [Header("Moving")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _rotSpeed = 0.05f;
    [SerializeField] float _animSpeed = 1.0f;

    [Header("TargetPoint")]
    [SerializeField] float _targetResearchCool;
    [SerializeField] float _researchCool = 1.0f;
    [SerializeField] float _targetPointAround = 1.0f;
    float _nowResearchCool = 0;

    Vector3 _targetPoint;
    Vector3 _moveVec;

    EnemyManager _em;

    public override void StartAction()
    {
        base.StartAction();
        if (_em == null)
            _em = _owner as EnemyManager;
        _targetPoint = new Vector3(_em.transform.position.x, 0, _em.transform.position.z);
        _nowResearchCool = 0;
        _animator.ResetTrigger("IsDamage");
        _animator.ResetTrigger("IsAtk");
        _animator.SetFloat("Moving", 0);
    }

    public override void CheckInputKeys(ActorController.InputKey key, ActorController.InputState state)
    {
        switch (key)
        {
            case ActorController.InputKey.NORMALATK:
                _owner.ChangeAction("Atk");
                break;

            case ActorController.InputKey.DODGE:
                break;
        }
    }

    void Awake()
    {
        _em = _owner as EnemyManager;
    }

    public override void UpdateAction()
    {
        SetTargetPoint();
        Moving();
    }

    void Moving()
    {
        _moveVec = (_targetPoint - new Vector3(_em.transform.position.x, 0, _em.transform.position.z)).normalized;

        if (_moveSpeed * Time.deltaTime >= Vector3.Distance(_targetPoint, new Vector3(_em.transform.position.x, 0, _em.transform.position.z)))
        {
            _em.transform.position = new Vector3(_targetPoint.x, _em.transform.position.y, _targetPoint.z);
            _animator.SetFloat("Moving", Mathf.Max(0, _animator.GetFloat("Moving") - _animSpeed * Time.deltaTime));
        }
        else
        {
            Quaternion targetDir = Quaternion.LookRotation(_moveVec);
            _animator.transform.rotation = Quaternion.Lerp(_animator.transform.rotation, targetDir, _rotSpeed);
            _em.transform.position += _moveVec * Time.deltaTime * _moveSpeed;
            _animator.SetFloat("Moving", Mathf.Min(1, _animator.GetFloat("Moving") + _animSpeed * Time.deltaTime));
        }
    }

    void SetTargetPoint()
    {
        _nowResearchCool -= Time.deltaTime;

        if (_nowResearchCool <= 0)
        {
            _targetPoint = _em._target.transform.position + new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)).normalized * _targetPointAround;

            _nowResearchCool = _targetResearchCool;
        }
    }
}
