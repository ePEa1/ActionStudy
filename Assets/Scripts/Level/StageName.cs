using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StageName : MonoBehaviour
{
    [SerializeField] RectTransform _image;
    [SerializeField] AnimationCurve _imageCurve;
    [SerializeField] float _imageSpeed;

    [SerializeField] Text _name;
    [SerializeField] AnimationCurve _nameCurve;
    [SerializeField] float _nameSpeed;
    [SerializeField] float _nameTimeStart = 0.5f;

    [SerializeField] float _closeTimeOrigin;

    [SerializeField] UnityEvent _finishEvent;

    float _closeTime = 0;
    float _nameTime = 0;
    float _imageTime = 0;

    private void OnEnable()
    {
        _closeTime = _closeTimeOrigin;
        _nameTime = _nameTimeStart;
        _imageTime = 0;
        _name.color = new Color(1, 1, 1, 0);
        _image.sizeDelta = new Vector2(0, 100);

    }

    private void Update()
    {
        _nameTime += Time.deltaTime * _nameSpeed;
        _imageTime += Time.deltaTime * _imageSpeed;

        _image.sizeDelta = new Vector2(_imageCurve.Evaluate(_imageTime) * 350, 100);
        _name.color = new Color(1, 1, 1, _nameCurve.Evaluate(_nameTime));

        _closeTime -= Time.deltaTime;
        if (_closeTime <= 0)
        {
            _finishEvent.Invoke();
            gameObject.SetActive(false);
        }
    }
}
