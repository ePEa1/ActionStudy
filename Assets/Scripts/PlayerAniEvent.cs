using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAniEvent : MonoBehaviour
{
    [SerializeField] UnityEvent[] _movingEvent;
    public enum MovingEnum
    {
        FOOTSTEP
    }

    [SerializeField] UnityEvent[] _dodgeEvent;
    public enum DodgeEnum
    {
        GETINPUT,
        FINISHDODGE
    }

    [SerializeField] UnityEvent[] _atkEvent;
    public enum AtkEnum
    {
        SETNEXTATK,
        CHECKNEXTATK
    }

    public void PlayMovingEvt(MovingEnum e) => _movingEvent[(int)e].Invoke();
    public void PlayDodgeEvt(DodgeEnum e) => _dodgeEvent[(int)e].Invoke();
    public void PlayAtkEvt(AtkEnum e) => _atkEvent[(int)e].Invoke();
}
