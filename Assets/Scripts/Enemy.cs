using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
           transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if (transform.position.y < -11f)
        {
            float randomy = Random.Range(-5.0f, 5.0f);
            transform.position = new Vector3(6, randomy, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player")
         {
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);
         }
        
            if (other.tag == "Laser")

            {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            }
    }

}