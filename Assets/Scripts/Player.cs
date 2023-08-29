using System.Collections;
using System.Collections.Generic;
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
    [SerializeField]
    private int _lives = 3;

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


        if (transform.position.y >= 4.4f)
        {
            transform.position = new Vector3(transform.position.x, 4.4f, 0);
        }
        else if (transform.position.y <= -4.4f)
        {
            transform.position = new Vector3(transform.position.x, -4.4f, 0);
        }
        if (transform.position.x > 9.1f)
        {
            transform.position = new Vector3(-8.1f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.1f)
        {
            transform.position = new Vector3(9.1f, transform.position.y, 0);
        }
    }
    void FireLaser()

    {
        _canFire = Time.time + _fireRate;
        Instantiate(_LaserPrefabs, transform.position + new Vector3(0.8f, 0, 0), Quaternion.identity);
    }

    public void Damage()
    {
        _lives -= 1;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }

    }

}
