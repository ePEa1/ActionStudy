using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    [SerializeField] float _boomTime = 1.0f;
    [SerializeField] Transform _floor;

    bool _on = false;

    float _time = 0;

    void OnEnable()
    {
        _on = false;
        _time = 0;
    }

    void Update()
    {
        _time += Time.deltaTime;
        _floor.localScale = new Vector3(Mathf.Min(1, _time / _boomTime), Mathf.Min(1, _time / _boomTime), 1);

        if (_time >= _boomTime && !_on)
        {
            _on = true;
            StopCoroutine("OnCollider");
            StartCoroutine("OnCollider");
        }
        //CheckDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TakeDamageData damData = new TakeDamageData();
            damData._damPow = 35;
            Vector3 knockDir = other.transform.position - transform.position;
            knockDir.y = 0;
            damData._knock = knockDir.normalized * 0.3f;
            other.transform.GetComponent<ITakeDamage>().TakeDamage(damData);
            GetComponent<BoxCollider>().enabled = false;

            _time = 0;
            gameObject.SetActive(false);
        }
    }

    void CheckDamage()
    {
        float half = Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.5f;

        RaycastHit[] hit = Physics.BoxCastAll(transform.position, Vector3.one * half, Vector3.zero);

        foreach (RaycastHit h in hit)
        {
            Debug.Log(h.transform.tag);
            if (h.transform.tag == "Player")
            {
                TakeDamageData damData = new TakeDamageData();
                damData._damPow = 35;
                damData._knock = Vector3.zero;
                h.transform.GetComponent<ITakeDamage>().TakeDamage(damData);
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        
    }

    IEnumerator OnCollider()
    {
        GetComponent<BoxCollider>().enabled = true;

        yield return 0;

        _time = 0;
        GetComponent<BoxCollider>().enabled = false;
        gameObject.SetActive(false);

        yield return 0;
    }
}
