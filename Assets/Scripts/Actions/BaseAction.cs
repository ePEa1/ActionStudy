using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] protected CharacterManager _owner;
    [SerializeField] protected Animator _animator;

    public virtual void StartAction() { }

    /// <summary>
    /// StartAction, EndAction
    /// </summary>
    public abstract void UpdateAction();

    public virtual void FixedUpdateAction() { }

    public virtual void EndAction() { }

    public virtual void CheckInputKeys(ActorController.InputKey key, ActorController.InputState state) { }

    public virtual void CheckMoveDir(Vector3 dir) { }
}
