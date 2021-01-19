using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScroller : MonoBehaviour
{

    int min = 12;
    float max = 48f;

    Vector3 move;

    [SerializeField] private float cubeMaxHeight;

    bool down = false;
    bool up = true;
    void Start()
    {


    }
    void Update()
    {


        float y = Mathf.PingPong(2 * Time.time, cubeMaxHeight);
        Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
        transform.position = pos;


        /*   if(transform.position.y >= 0 && 15 >= transform.position.y)
           {

               if (down)
               {
                    move = new Vector3(0, -0.2f, 0);
                   if (transform.position.y <= 0)
                   {
                       transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                       down = false;
                       up = true;

                   }
               }
              else  if (up)
               {
                    move = new Vector3(0 , 0.2f, 0);
                   if (transform.position.y >= 15.0)
                   {
                       transform.position = new Vector3(transform.position.x, 15, transform.position.z);
                       up = false;
                       down = true;
                   }
               }

               transform.position = transform.position + move;

           }*/





    }
}
