using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDodgeBar : MonoBehaviour
{
    [SerializeField] PlayerStat _stat;

    [SerializeField] Slider[] _slider;

    float _maxDodgeGage;

    void Start()
    {
        _maxDodgeGage = _stat._nowDodgeGage;

        for(int i=0;i<_slider.Length;i++)
        {
            _slider[i].maxValue = i + 1;
            _slider[i].minValue = i;
            _slider[i].value = _stat._nowDodgeGage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Slider s in _slider)
            s.value = _stat._nowDodgeGage;

        if (_slider[_slider.Length - 1].value == _maxDodgeGage && _slider[0].gameObject.activeSelf)
            foreach (Slider bar in _slider)
                bar.gameObject.SetActive(false);

        if (_slider[_slider.Length - 1].value < _maxDodgeGage && !_slider[0].gameObject.activeSelf)
            foreach (Slider bar in _slider)
                bar.gameObject.SetActive(true);
    }
}
