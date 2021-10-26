using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBar : MonoBehaviour
{
    [SerializeField] float _closeTime;

    float _time = 0;

    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _closeTime)
            gameObject.SetActive(false);
    }
}
