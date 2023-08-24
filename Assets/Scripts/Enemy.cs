using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.9f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move enmy left
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        // when enemy is off the screen respond
        // find random positioin for x

        if (transform.position.x < -12f)
        {
            float randomY = Random.Range(-4f, 6f);
            transform.position = new Vector3(12, randomY, 0);
        }

    }
    private void OnTriggerEnter(Collider other)

    {

    }
}
