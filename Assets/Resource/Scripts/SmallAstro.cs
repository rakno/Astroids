using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAstro : MonoBehaviour
{

   

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
}
