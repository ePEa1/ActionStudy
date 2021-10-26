using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearText : MonoBehaviour
{
    [SerializeField] Vector2 _addPos;
    [SerializeField] AnimationCurve _moveAc;
    [SerializeField] float _moveSpeed;

    [SerializeField] AnimationCurve _colorAc;
    [SerializeField] float _startTime;
    [SerializeField] float _colorSpeed;

    Text _text;
    Vector2 _origin;
    RectTransform _rect;
    float _nowTime = 0;
    float _nowColor = 0;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _rect = GetComponent<RectTransform>();
        _origin = _rect.anchoredPosition;
    }

    void OnEnable()
    {
        _nowColor = 0;
        _nowTime = 0;
        _rect.anchoredPosition = _origin;
        _text.color = Color.white;
    }

    void Update()
    {
        _nowTime += Time.deltaTime * _moveSpeed;
        _nowColor += Time.deltaTime * _colorSpeed;

        _rect.anchoredPosition = _origin + _addPos * _moveAc.Evaluate(_nowTime);
        _text.color = new Color(1, 1, 1, _colorAc.Evaluate(_nowColor - _startTime));
    }
}
