using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] UnityEvent _startEvent;
    [SerializeField] UnityEvent _clearEvent;
    [SerializeField] Transform _clearWall;

    bool _isClear = false;

    public void StartLevel()
    {
        _startEvent.Invoke();
    }

    private void Update()
    {
        if (_isClear)
            OpenWall();
    }

    public void FinishLevel()
    {
        _clearEvent.Invoke();
        _isClear = true;
    }

    void OpenWall()
    {
        _clearWall.position += Vector3.down * Time.deltaTime * 4;
    }
}
