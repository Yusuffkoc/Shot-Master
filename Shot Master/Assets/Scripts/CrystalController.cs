using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrystalController : MonoBehaviour
{
    
    
    public  GameObject brokenObject;
    public float magnitudeCol, radius, power, upwards;

    public AudioClip BreakSound;
    [SerializeField] [Range(0, 1)] private int volume;


    void Start()
    {
        
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position, volume);

            StartCoroutine(DestroyCrsytal());

            Instantiate(brokenObject, transform.position, transform.rotation);
            //brokenObject.transform.localScale = transform.localScale;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius);
                }
            }
        }
    }

    IEnumerator DestroyCrsytal()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
