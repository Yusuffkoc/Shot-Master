using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    
    private Rigidbody rb;

    bool isEndLevel;
    
    //Kamera Hızı GameManagerdan kontrol ediliyor.
    [HideInInspector]
    public float cameraSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isEndLevel = false;
    }

    
    void Update()
    {
        //float horizontal = Input.GetAxisRaw("Vertical");

        if (!isEndLevel)
        {
            CameraMovement();
        }
        
    }

    private void CameraMovement()
    {
        Vector3 mov = new Vector3(0, 0, cameraSpeed);
        //rb.AddForce(mov);
        rb.velocity = mov;
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            rb.isKinematic = true;
            
        }
    }
}
