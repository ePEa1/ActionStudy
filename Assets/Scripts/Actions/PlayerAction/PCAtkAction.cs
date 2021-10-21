using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static ActorController;
using static CustomPhysics;

public class PCAtkAction : BaseAction
{
    [SerializeField] PlayerStat _stat;

    bool _isNextAtk = false;
    bool _nextAtkOk = false;

    bool _finishAtk = false;

    bool _isRotate = false;


    #region Field - AttackDatas
    [Header("Atk Datas")]
    [SerializeField] BoxCollider _collider;
    [SerializeField] AtkStatDataAsset[] _atkStats;
    [SerializeField] AtkEffDataAsset[] _atkEffs;
    [SerializeField] int _maxCombo = 0;
    int _nowCombo = 0;
    int _nowAtk = 0;
    #endregion

    #region Field - Effect 
    ParticleSystem[] _atkParticle;
    float _fixedTimer = 0.0f;
    int _particleNum = 0;
    float[] _playParticleTime;
    #endregion

    #region Field - Moving
    float _moveTimer = 0.0f;
    float _beforeTime = 0.0f;
    [SerializeField] LayerMask _wall;

    [SerializeField] AudioSource _ac;
    #endregion

    public override void UpdateAction() 
    {
        if (_isRotate)
        {
            _isRotate = false;
            PlayerManager pm = _owner as PlayerManager;
            _animator.transform.rotation = Quaternion.Euler(0.0f, pm.Cam.transform.eulerAngles.y, 0.0f);
        }

        //Moving----------------------------
        _moveTimer += Time.deltaTime;
        AtkStatDataAsset data = _atkStats[_nowCombo];
        float speed = (data._moveCurve.Evaluate(_moveTimer) - data._moveCurve.Evaluate(_beforeTime)) * data._moveRange;

        Vector3 moveRay = _animator.transform.rotation * Vector3.forward;
        //Debug.Log(moveRay);
        _owner.transform.position = FixedMoveVector(_owner.transform.position, moveRay * speed, _wall);
        _beforeTime = _moveTimer;
        //-----------------------------------

        //Damage Check--------------------------
        if (data._damDatas.Length > _nowAtk)
        {
            if (_moveTimer >= data._damDatas[_nowAtk]._hitTiming)
            {
                _ac.clip = data._damDatas[_nowAtk]._atkSFX;
                _ac.Play();

                _collider.transform.rotation = _animator.transform.rotation;
                _collider.size = data._damDatas[_nowAtk]._atkRange;
                _collider.center = data._damDatas[_nowAtk]._atkCenter;

                TakeDamageData d = new TakeDamageData();
                d._damPow = data._damDatas[_nowAtk]._power;
                d._knock = _animator.transform.rotation * new Vector3(0, 0, data._damDatas[_nowAtk]._knockPower);
                _collider.GetComponent<AtkCollider>()._TakeDamageData = d;

                _collider.gameObject.SetActive(true);
                StartCoroutine(OffAtkCollider());

                _nowAtk++;
            }
        }
        //--------------------------------------
    }

    IEnumerator OffAtkCollider()
    {
        yield return new WaitForSeconds(0.05f);

        _collider.gameObject.SetActive(false);
    }

    public override void FixedUpdateAction()
    {
        _fixedTimer += Time.deltaTime;

        //Play Effect-----------
        if (_particleNum < _playParticleTime.Length)
            if (_fixedTimer >= _playParticleTime[_particleNum])
            {
                if (!_atkEffs[_nowCombo]._effDatas[_particleNum]._isChildren)
                    _atkParticle[_particleNum].transform.parent = null;
                _atkParticle[_particleNum++].Play();
            }
        //-------------------
    }

    public override void StartAction()
    {
        _nowCombo = 0;
        _nowAtk = 0;
        _particleNum = 0;
        _finishAtk = false;
        _animator.SetBool("IsAtk", true);
        _animator.SetTrigger("FirstAtk");
        PlayAtk();
    }

    public override void EndAction()
    {
        _isNextAtk = false;
        _nextAtkOk = false;
        _finishAtk = false;
        _animator.ResetTrigger("FirstAtk");
        _animator.SetBool("IsAtk", false);
        _animator.ResetTrigger("Atk");
    }

    public override void CheckInputKeys(InputKey key, InputState state)
    {
        //다음 공격 예약
        if (key == InputKey.NORMALATK && state == InputState.PRESSED)
            if (/*_nextAtkOk && */!_isNextAtk) _isNextAtk = true;

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
            _nowCombo = _nowCombo + 1 >= _maxCombo ? 0 : _nowCombo + 1;
            _isNextAtk = false;
            _nextAtkOk = false;
            _animator.SetBool("IsAtk", true);
            _animator.SetTrigger("Atk");
            PlayAtk();
        }
        else
        {
            _finishAtk = true;
            _animator.SetBool("IsAtk", false);
            _animator.ResetTrigger("Atk");
        }
    }

    void PlayAtk()
    {
        _fixedTimer = 0.0f;
        _moveTimer = 0.0f;
        _beforeTime = 0.0f;
        _particleNum = 0;
        _nowAtk = 0;

        
        _isRotate = true;

        # region Create Effect
        
        _atkParticle = new ParticleSystem[_atkEffs[_nowCombo]._effDatas.Length];
        _playParticleTime = new float[_atkParticle.Length];

        for (int i = 0; i < _atkParticle.Length; i++)
        {
            AtkEffData eData = _atkEffs[_nowCombo]._effDatas[i];
            _playParticleTime[i] = eData._spawnTiming;
            GameObject eff = Instantiate(_atkEffs[_nowCombo]._effDatas[i]._effObject);

            PlayerManager pm = _owner as PlayerManager;
            Vector3 dirVector = pm.Cam.transform.rotation * Vector3.forward;
            dirVector.y = 0;
            dirVector = dirVector.normalized;
            Quaternion dirQua = Quaternion.LookRotation(dirVector);

            eff.transform.parent = _owner.transform;
            eff.transform.localPosition = Quaternion.Euler(0.0f, pm.Cam.transform.eulerAngles.y, 0.0f) * eData._position;
            eff.transform.rotation = dirQua * Quaternion.Euler(eData._angle);

            _atkParticle[i] = eff.GetComponent<ParticleSystem>();
            Destroy(eff.gameObject, eData._spawnTiming + 1.0f);
        }

        #endregion
    }
}
