using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    public virtual void MovingCheck(Vector3 moveDir) { }
    public virtual void OnNormalAtk(ActorController.InputState state) { }
    public virtual void OnDodge(ActorController.InputState state) { }

}