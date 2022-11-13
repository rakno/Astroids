using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    float rocketForce = 10;
    float rocketTorque = 1f;
    public GameObject bullet;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
             rb.AddRelativeForce(new Vector2(0, rocketForce), ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(rocketTorque);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-rocketTorque);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shooting();
        }



    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Bullet")
        {
            transform.position = new Vector3(Random.Range(1, 22), Random.Range(1, 8), 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void Shooting()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0),transform.rotation);
    }
}
