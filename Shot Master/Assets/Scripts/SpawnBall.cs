using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    //Prefab Playerımız
    [SerializeField] private GameObject ballGO;

    //Sahip oldugumuz atılabilir top sayısı
    [SerializeField] private int ownBallNumber;
    //Sahip oldugumuz atılabilir crystal sayısı
    [SerializeField] private int NumberOfCrsytals;

    [SerializeField] private GameObject camera;

    [SerializeField] private TextMeshProUGUI throvawayBallText;

    [HideInInspector]
    [SerializeField] private float waitSpawnTime=5f;

    
    [SerializeField] private Transform spawnPointsTransform;

  
    

    [SerializeField] private GameObject RestartPanelGO;

    GameObject ourBall;
    [SerializeField] private float radius;
    bool canSpawn;

    private void Awake()
    {
        RestartPanelGO.SetActive(false);


        throvawayBallText.text = ownBallNumber.ToString();
    }
    

    void LateUpdate()
    {
        
        Vector3 explosionPos = camera.gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Player")
            {
                ourBall = colliders[i].gameObject;
                
                break;
            }
        }


        foreach (var item in colliders)
        {
            if (item.tag == "Player" && ourBall != null)
            {
                canSpawn = false;
            }
            else if (ourBall == null)
            {
                canSpawn = true;
            }
            
        }

        if (ownBallNumber == 0)
        {
            gameManager.CameraSpeed = 0;
            RestartPanelGO.SetActive(true);
        }

        if (canSpawn == true && ownBallNumber != 0)
        {
            IncreaseBallNumber();
            InstantiateBall();
        }
        

        
    }

    private void IncreaseBallNumber()
    {
        ownBallNumber--;
        throvawayBallText.text = ownBallNumber.ToString();

    }

    private void InstantiateBall()
    {
     
        Instantiate(ballGO, spawnPointsTransform.transform.position, spawnPointsTransform.transform.rotation);

    }

    
}
