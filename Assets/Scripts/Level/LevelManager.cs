using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] UnityEvent _startEvent;
    [SerializeField] Transform _clearWall;

    bool _isClear = false;

    public void StartLevel()
    {
        _startEvent.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            _isClear = true;

        if (_isClear)
            FinishLevel();
    }

    public void FinishLevel()
    {
        _clearWall.position += Vector3.down * Time.deltaTime;
    }
}
