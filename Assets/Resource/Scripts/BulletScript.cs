using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject smallAstro;
     AudioSource AstroBlast;
  
     GameManager gm;
    public float speed = 5;
    public LayerMask lm;
    
    // Start is called before the first frame update
    void Start()
    {
     
        
        GameObject go = GameObject.FindWithTag("GameManager");
        gm = go.GetComponent<GameManager>();
       
        GameObject.Destroy(gameObject, 4f);

        AstroBlast = gameObject.GetComponent<AudioSource>();


    }

    void Update()
    {
        transform.position = transform.position + speed * transform.up * Time.deltaTime;
        RaycastHit2D rch = Physics2D.Raycast(transform.position, transform.up, speed * Time.deltaTime);
        if (rch.collider != null)
        {
            bool ifLarge = rch.collider.gameObject.CompareTag("LargeAstro");
            bool ifSmall = rch.collider.gameObject.CompareTag("SmallAstro");
            if (ifLarge)
            {
                //playastroBlast
                GameObject.Destroy(gameObject);
                GameObject.Destroy(rch.collider.gameObject);
                AstroBlast.Play();
                Instantiate(smallAstro, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 75));
             
                Instantiate(smallAstro, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, 0), Quaternion.Euler(0, 0, 295));
                gm.ScoreIncrease();
                gm.SplitingAstro();
                
            }
            if (ifSmall)
            {
                //playAstroBlast
                GameObject.Destroy(gameObject);
                GameObject.Destroy(rch.collider.gameObject);
                 AstroBlast.Play();
                gm.DestroyingNumberofAstro();
                gm.ScoreIncrease();
            }


        }
    }


}
