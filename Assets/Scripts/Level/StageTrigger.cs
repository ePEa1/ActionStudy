using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageTrigger : MonoBehaviour
{
    [SerializeField] GameObject _safeTile;
    [SerializeField] GameObject _wall;
    [SerializeField] UnityEvent _stageEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _safeTile.SetActive(false);
            _wall.SetActive(true);
            _stageEvent.Invoke();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
