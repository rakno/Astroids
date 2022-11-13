using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{

    AudioSource blastSound;
    public GameObject smallAstro;
    Rigidbody2D rb;
    private GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject go = GameObject.FindWithTag("GameManager");

        gameManager = go.GetComponent<GameManager>();
        rb.AddForce(transform.up * Random.Range(-40f, 160f));
        rb.angularVelocity = Random.Range(10f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(collision.gameObject);
            if(tag.Equals("LargeAstro"))
            {
                Instantiate(smallAstro,
             new Vector3(transform.position.x-0.5f,transform.position.y-0.5f, 0),
              Quaternion.Euler(0, 0, 75));

                Instantiate(smallAstro,
             new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, 0),
              Quaternion.Euler(0, 0, 295));
            }
        }
    
    }
}
