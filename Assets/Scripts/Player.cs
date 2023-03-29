using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _LaserPrefabs;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) 

        {
            FireLaser();

        }

    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);


        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
        if (transform.position.x > 10.2F)
        {
            transform.position = new Vector3(-10.2F, transform.position.y, 0);
        }
        else if (transform.position.x < -10.2F)
        {
            transform.position = new Vector3(transform.position.y, 0);
        }
    }
    void FireLaser()

    {
        _canFire = Time.time + _fireRate;
        Instantiate(_LaserPrefabs, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
    }

}
