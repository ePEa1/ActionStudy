using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AtkCollider : MonoBehaviour
{
    [SerializeField] string[] _targetTag;
    public TakeDamageData _TakeDamageData { get; set; }

    public List<Action> _takeDamageAction = new List<Action>();

    private void OnTriggerEnter(Collider other)
    {
        foreach(string targetTag in _targetTag)
        {
            if (other.transform.tag == targetTag)
            {
                other.GetComponent<ITakeDamage>().TakeDamage(_TakeDamageData);
                foreach (Action action in _takeDamageAction)
                    action.Invoke();
            }
        }
    }
}

public interface ITakeDamage
{
    void TakeDamage(TakeDamageData data);
}

public class TakeDamageData
{
    public float _damPow = 0;
    public Vector3 _knock = Vector3.zero;
}