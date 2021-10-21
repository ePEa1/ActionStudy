using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Tips : MonoBehaviour
{
    [SerializeField] Vector2 _size;

    [SerializeField] RectTransform _image;
    [SerializeField] AnimationCurve _imageCurve;
    [SerializeField] float _imageSpeed;

    [SerializeField] Image[] _tipImg;
    [SerializeField] Text[] _name;
    [SerializeField] AnimationCurve _nameCurve;
    [SerializeField] float _nameSpeed;
    [SerializeField] float _nameTimeStart = 0.5f;

    [SerializeField] UnityEvent _event;

    float _nameTime = 0;
    float _imageTime = 0;

    private void OnEnable()
    {
        _nameTime = _nameTimeStart;
        _imageTime = 0;
        foreach (Text t in _name)
            t.color = new Color(1, 1, 1, 0);
        foreach(Image img in _tipImg)
            img.color = new Color(1, 1, 1, 0);
        _image.sizeDelta = new Vector2(0, _size.y);

    }

    private void Update()
    {
        _nameTime += Time.deltaTime * _nameSpeed;
        _imageTime += Time.deltaTime * _imageSpeed;

        _image.sizeDelta = new Vector2(_imageCurve.Evaluate(_imageTime) * _size.x, _size.y);

        foreach (Text t in _name)
            t.color = new Color(1, 1, 1, _nameCurve.Evaluate(_nameTime));
        foreach(Image img in _tipImg)
            img.color = new Color(1, 1, 1, _nameCurve.Evaluate(_nameTime));

        if (Input.GetKeyDown(KeyCode.G))
        {
            gameObject.SetActive(false);
            _event.Invoke();
        }
    }
}
