using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    [SerializeField] float _boomTime = 1.0f;
    [SerializeField] Transform _floor;

    float _time = 0;

    void OnEnable()
    {
        _time = 0;
    }

    void Update()
    {
        _time += Time.deltaTime;
        _floor.localScale = new Vector3(Mathf.Min(1, _time / _boomTime), Mathf.Min(1, _time / _boomTime), 1);

        if (_time >= _boomTime)
        {
            CheckDamage();
        }
    }

    void CheckDamage()
    {
        RaycastHit[] hit = Physics.BoxCastAll(transform.position, Vector3.one * 5, Vector3.zero);

        foreach(RaycastHit h in hit)
        {
            if (h.transform.tag == "Player")
            {
                TakeDamageData damData = new TakeDamageData();
                damData._damPow = 35;
                damData._knock = Vector3.zero;
                h.transform.GetComponent<ITakeDamage>().TakeDamage(damData);
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        _time = 0;
        gameObject.SetActive(false);
    }
}
