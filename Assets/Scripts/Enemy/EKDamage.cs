using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKDamage : BaseAction, ITakeDamage
{
    [SerializeField] GameObject _hitVFX;

    [Header("Action Data")]
    [SerializeField] AudioClip[] _clip;
    [SerializeField] AudioSource _ac;

    TakeDamageData _damData;

    public void Awake()
    {
        _ac = GetComponent<AudioSource>();
    }

    public override void UpdateAction()
    {

    }

    public override void StartAction()
    {
        _owner.transform.position += _damData._knock;

        _ac.clip = _clip[Random.Range(0, _clip.Length)];
        _ac.Play();

        GameObject vfx = Instantiate(_hitVFX);
        vfx.transform.localRotation = Quaternion.LookRotation(_damData._knock.normalized * -1) * Quaternion.Euler(Random.Range(-30.0f, 30.0f), 90, 0);
        vfx.transform.position = _owner.transform.position + _damData._knock.normalized * -1 + Vector3.up * 1.0f;
        vfx.transform.parent = _owner.transform;

        Destroy(vfx, 1.0f);
    }

    public void TakeDamage(TakeDamageData data)
    {
        _damData = data;

        _owner._nowHp = Mathf.Max(0, _owner._nowHp - _damData._damPow);
        Debug.Log("Damage : " + _damData._damPow);
        
        _owner.ChangeAction("Damage");
    }
}
