using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDodgeBar : MonoBehaviour
{
    [SerializeField] PlayerStat _stat;

    [SerializeField] Slider[] _slider;

    void Start()
    {
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
    }
}
