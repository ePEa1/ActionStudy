using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ActorController;

public class PCAtkAction : BaseAction
{
    [SerializeField] PlayerStat _stat;

    bool _isNextAtk = false;
    bool _nextAtkOk = false;

    bool _finishAtk = false;

    bool _isRotate = false;


    #region AttackDatas
    [Header("Atk Datas")]
    [SerializeField] AtkStatDataAsset[] _atkStats;
    [SerializeField] AtkEffDataAsset[] _atkEffs;
    [SerializeField] int _maxCombo = 0;
    float _timer = 0.0f;
    int _nowCombo = 0;

    ParticleSystem[] _atkParticle;
    int _particleNum = 0;
    float[] _playParticleTime;

    #endregion

    public override void UpdateAction() 
    {
        if (_isRotate)
        {
            _isRotate = false;
            PlayerManager pm = _owner as PlayerManager;
            _animator.transform.rotation = Quaternion.Euler(0.0f, pm.Cam.transform.eulerAngles.y, 0.0f);
        }
    }

    public override void FixedUpdateAction()
    {
        _timer += Time.deltaTime;
        if (_particleNum < _playParticleTime.Length)
            if (_timer >= _playParticleTime[_particleNum])
                _atkParticle[_particleNum++].Play();
    }

    public override void StartAction()
    {
        _nowCombo = 0;
        _particleNum = 0;
        _finishAtk = false;
        PlayAtk();
    }

    public override void EndAction()
    {
        _isNextAtk = false;
        _nextAtkOk = false;
        _finishAtk = false;
        _animator.SetBool("IsAtk", false);
        _animator.ResetTrigger("Atk");
    }

    public override void CheckInputKeys(InputKey key, InputState state)
    {
        //다음 공격 예약
        if (key == InputKey.NORMALATK && state == InputState.PRESSED)
            if (_nextAtkOk && !_isNextAtk) _isNextAtk = true;

        //회피(공격 캔슬 가능)
        if (key == InputKey.DODGE && state == InputState.PRESSED && _stat._isDodgeOk)
            _owner.ChangeAction("Dodge");
    }

    public override void CheckMoveDir(Vector3 dir)
    {
        if (!_isNextAtk && _finishAtk)
        {
            if (dir == Vector3.zero) _owner.ChangeAction("Idle");
            else _owner.ChangeAction("Moving");
        }
    }

    public void SetNextAtk() => _nextAtkOk = true;

    public void CheckNextAtk()
    {
        if (_isNextAtk)
        {
            _isNextAtk = false;
            _nextAtkOk = false;
            PlayAtk();
        }
        else
        {
            _finishAtk = true;
        }
    }

    void PlayAtk()
    {
        _timer = 0.0f;
        _particleNum = 0;

        _animator.SetBool("IsAtk", true);
        _animator.SetTrigger("Atk");
        _isRotate = true;

        # region Create Effect
        
        _atkParticle = new ParticleSystem[_atkEffs[_nowCombo]._effDatas.Length];
        _playParticleTime = new float[_atkParticle.Length];

        for(int i=0;i<_atkParticle.Length;i++)
        {
            AtkEffData eData = _atkEffs[_nowCombo]._effDatas[i];
            _playParticleTime[i] = eData._spawnTiming;
            GameObject eff = Instantiate(_atkEffs[_nowCombo]._effDatas[i]._effObject);

            PlayerManager pm = _owner as PlayerManager;
            Vector3 dirVector = pm.Cam.transform.rotation * Vector3.forward;
            dirVector.y = 0;
            dirVector = dirVector.normalized;
            Quaternion dirQua = Quaternion.LookRotation(dirVector);

            if (eData._isChildren)
            {
                eff.transform.parent = _owner.transform;
                eff.transform.localPosition = eData._position;
            }
            else
            {
                eff.transform.position = _owner.transform.position + dirQua * eData._position;
            }
            eff.transform.rotation = dirQua * Quaternion.Euler(eData._angle);

            _atkParticle[i] = eff.GetComponent<ParticleSystem>();
            Destroy(eff.gameObject, eData._spawnTiming + 1.0f);
        }
        
        #endregion


        _nowCombo = _nowCombo + 1 >= _maxCombo ? 0 : _nowCombo + 1;
    }
}
