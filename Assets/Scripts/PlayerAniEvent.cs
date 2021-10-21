using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAniEvent : MonoBehaviour
{
    [SerializeField] UnityEvent[] _movingEvent;
    public enum MovingEnum
    {
        FOOTSTEP
    }

    [SerializeField] UnityEvent[] _damageEvent;
    public enum DamageEnum
    {
        EndDamage
    }

    [SerializeField] UnityEvent[] _atkEvent;
    public enum AtkEnum
    {
        SETNEXTATK,
        CHECKNEXTATK
    }

    public void PlayMovingEvt(MovingEnum e) => _movingEvent[(int)e].Invoke();
    public void PlayDamageEvt(DamageEnum e) => _damageEvent[(int)e].Invoke();
    public void PlayAtkEvt(AtkEnum e) => _atkEvent[(int)e].Invoke();
}
