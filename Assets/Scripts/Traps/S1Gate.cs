using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1Gate : MonoBehaviour, ITakeDamage
{
    [SerializeField] float _maxHp = 100;
    [SerializeField] float _shakePower;
    [SerializeField] float _shakeDown;
    [SerializeField] Slider _hpBar;
    [SerializeField] Transform _uiCenter;
    float _hp;
    float _nowHp { get { return _hp; } set { ChangeHp(value); } }

    [SerializeField] AudioSource _audio;

    public void TakeDamage(TakeDamageData data)
    {
        _nowHp = _nowHp - data._damPow;
    }

    void Awake()
    {
        _hp = _maxHp;
        _hpBar.maxValue = _maxHp;
        _hpBar.value = _maxHp;
    }

    void ChangeHp(float hp)
    {
        if (_hp > hp)
        {
            StopCoroutine("ShakeBar");
            StartCoroutine(ShakeBar(_shakePower));
            _audio.Play();
        }
        _hp = Mathf.Max(0, hp);
        _hpBar.value = _hp;
    }

    IEnumerator ShakeBar(float pow)
    {
        float shakePow = pow;
        Vector3 origin = _uiCenter.position;

        while(shakePow>0)
        {
            _uiCenter.position += _uiCenter.rotation * new Vector3(Random.Range(1, 1), Random.Range(-1, 1), 0).normalized * shakePow;

            yield return new WaitForSeconds(0.05f);

            _uiCenter.position = origin;
            shakePow = Mathf.Max(0, shakePow - _shakeDown * Time.deltaTime);

            yield return new WaitForSeconds(0.05f);
        }
    }
}
