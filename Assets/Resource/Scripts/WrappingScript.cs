using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappingScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 22.3f)
        {
            transform.position = new Vector3(0.5f, transform.position.y, 0);
        }

        else if(transform.position.x<=0.5f)
        {
            transform.position = new Vector3(22.3f, transform.position.y, 0);
        }

        else if(transform.position.y >= 12.5)
        {

           transform.position = new Vector3(transform.position.x,0.5f, 0);
        }

        else if(transform.position.y<=0.5)
        {
            transform.position = new Vector3(transform.position.x, 12.5f, 0);
        }
    }
}
