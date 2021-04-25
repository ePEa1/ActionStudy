using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterManager : MonoBehaviour
{
    [Header("System")]
    [SerializeField] protected Animator _animator;

    [Header("Action Setting")]
    [SerializeField] protected BaseAction[] _actions;
    [SerializeField] protected string[] _statName;
    [SerializeField] protected string _startStat;

    protected Dictionary<string, int> _stats;
    protected string _nowStat;
    
    BaseAction _nowAction;

    /// <summary>
    /// _stats에 액션 이름 넣고 _nowStat이랑 _nowAction 초기값 셋팅해주기
    /// </summary>
    protected abstract void ManagerSetup();

    protected void UpdateAction()=> _nowAction.UpdateAction();

    public void SetAction(string action)
    {
        _nowStat = action;
        _nowAction = _actions[_stats[action]];
        _nowAction.StartAction();
    }

    public void ChangeAction(string action)
    {
        _nowAction.EndAction();
        SetAction(action);
    }
}
