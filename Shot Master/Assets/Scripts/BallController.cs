using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    
    [SerializeField] private float shootPower=30f;

    public AudioClip BreakSound;
    [SerializeField][Range(0,1)] private int volume;



    CameraMov ballSpeedWithCamera;

    public bool isMoving=true;
    public bool canSpawn;

    [SerializeField] private GameObject GameController;

    SpawnBall OneShoot;

    [SerializeField] private float radius;

    float max;
   
    void Start()
    {
        max = transform.position.y + 1;
        //ballCount = GameManager.GetComponent<SpawnBall>();



        rb = GetComponentInParent<Rigidbody>();
        ballSpeedWithCamera = Camera.main.GetComponent<CameraMov>();
        
    }
    void Update()
    {
        //GameController = GameObject.FindGameObjectWithTag("GameController");
        //OneShoot = GameController.GetComponent<SpawnBall>();


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Rayi screen ekranında görebilirsin.
        //Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

        Vector3 ballSpeed = new Vector3(0, 0, ballSpeedWithCamera.cameraSpeed);

        
        if (Input.GetMouseButtonDown(0) && ballSpeedWithCamera.cameraSpeed > 0 && transform.position.y < max)
        {
           
            isMoving = false;
            RaycastHit hitInfo;

            if (Physics.Raycast(transform.position, transform.forward, out hitInfo) )
            {
                rb.AddForce(ray.direction * shootPower, ForceMode.VelocityChange);
                

            }

        }
        else if (isMoving)
        { 
            
            rb.velocity = ballSpeed;
            
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Destroy(gameObject);
            
        }

        if (other.gameObject.tag == "FinishLine" || other.gameObject.tag == "SkyLine")
        {
            Destroy(gameObject);
            
        }

        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cyrstal")
        {
            //AudioSource.PlayClipAtPoint(BreakSound,Camera.main.transform.position,volume);
            Destroy(gameObject);
        }
    }



}
