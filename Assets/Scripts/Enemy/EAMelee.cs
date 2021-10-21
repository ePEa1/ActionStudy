using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActorController;

public class EAMelee : BaseAction
{
    [SerializeField] float _atkRange = 2.0f;
    [SerializeField] float _forwardAngle = 45.0f;

    EnemyManager _em;


    private void Awake()
    {
        _em = _owner as EnemyManager;
    }

    public override void UpdateAction()
    {
    }

    private void Update()
    {
        //공격 트리거 작동-------------------
         Vector3 op = new Vector3(_owner.transform.position.x, 0, _owner.transform.position.z);
         Vector3 tp = new Vector3(_em._target.transform.position.x, 0, _em._target.transform.position.z);

        float dot = Vector3.Dot((tp - op).normalized, (Quaternion.Euler(0, _animator.transform.eulerAngles.y, 0) * Vector3.forward).normalized);

        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        float dis = Vector3.Distance(op, tp);

        if ((dis < _atkRange) && (angle < _forwardAngle))
            _owner.OnNormalAtk(ActorController.InputState.PRESSED);
        //-----------------------------------
    }

    public override void StartAction()
    {
        Vector3 op = new Vector3(_owner.transform.position.x, 0, _owner.transform.position.z);
        Vector3 tp = new Vector3(_em._target.transform.position.x, 0, _em._target.transform.position.z);
        _animator.transform.rotation = Quaternion.LookRotation(tp - op);

        _animator.SetTrigger("Atk");
    }

    void CheckInputKeys(InputKey keys)
    {

    }

    private void FixedUpdate()
    {
        
    }
}
