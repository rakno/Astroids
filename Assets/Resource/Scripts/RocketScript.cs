using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RocketScript : MonoBehaviour
{
    float rocketForce = 10;
    float rocketTorque = 1f;
    public GameObject bullet;
    GameManager gameM;
    AudioSource shootingSound;
    Rigidbody2D rb;
    float cd_max = 0.5f;
    float cd_counter;
  
    // Start is called before the first frame update
    void Start()
    {
        shootingSound = gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        GameObject go = GameObject.FindWithTag("GameManager");
        gameM = go.GetComponent<GameManager>();
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
        cd_counter -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {

            TryShooting();
        }



    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Bullet")
        {
            transform.position = new Vector3(Random.Range(1, 22), Random.Range(1, 8), 0);
            rb.velocity = new Vector3(0, 0, 0);
            gameM.LifeLoss();
        }
    }
    public void TryShooting()
    {
        if (cd_counter <= 0)
        {
             Shooting();
            cd_counter = cd_max;

        }

    }
    public void Shooting()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0),transform.rotation);
        shootingSound.Play();
       
    }
}
