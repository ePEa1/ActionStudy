using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaderTrap : MonoBehaviour
{
    [SerializeField] Vector3 _dir;

    [SerializeField] float _moveSpeed;

    [SerializeField] float _lifeTime;

    float _nowLifeTime = 0.0f;

    void OnEnable()
    {
        _nowLifeTime = _lifeTime;
    }

    void Update()
    {
        transform.position += _dir * _moveSpeed * Time.deltaTime;

        _nowLifeTime -= Time.deltaTime;
        if (_nowLifeTime <= 0)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TakeDamageData data = new TakeDamageData();
            data._damPow = 35;
            data._knock = _dir.normalized * 0.5f;
            other.GetComponent<ITakeDamage>().TakeDamage(data);
        }
    }
}
