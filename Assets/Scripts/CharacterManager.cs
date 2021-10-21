using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class CharacterManager : Actor
{
    [Header("Character Stat")]
    [SerializeField] protected float _maxHp = 100;

    float _nowhp;
    public float _nowHp { get { return _nowhp; } set { ChangeHp(value); } }

    [Header("Action Setting")]
    [SerializeField] ActionData[] _actions;
    [SerializeField] string _startStat;

    Dictionary<string, BaseAction> _stats;
    protected string _nowStat;
    
    protected BaseAction _nowAction;

    [SerializeField] Animator _animator;

    public List<Action<float>> _damageEvents = new List<Action<float>>();

    protected virtual void SetupActions()
    {
        _stats = new Dictionary<string, BaseAction>();
        for (int i = 0; i < _actions.Length; i++)
            _stats.Add(_actions[i]._statName, _actions[i]._action);

        SetAction(_startStat);
    }

    protected virtual void ChangeHp(float hp)
    {
        if (_nowhp > hp)
            foreach (Action<float> damEvent in _damageEvents)
                damEvent.Invoke(hp);
        _nowhp = hp;
    }

    public void Awake()
    {
        _nowHp = _maxHp;
        SetupActions();
    }
    protected void Update()
    {
        _nowAction.UpdateAction();
        _animator.transform.position = transform.position;
    }
    protected void FixedUpdate() => _nowAction.FixedUpdateAction();

    public void SetAction(string action)
    {
        _nowStat = action;
        _nowAction = _stats[action];
        _nowAction.StartAction();
    }

    public void ChangeAction(string action)
    {
        _nowAction.EndAction();
        SetAction(action);
    }
}

[System.Serializable]
public class ActionData
{
    public string _statName;
    public BaseAction _action;
}