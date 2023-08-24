using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _speed = 8.0f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);


        if (transform.position.x > 11f) 

        Destroy(this.gameObject);

    
    }
}
 