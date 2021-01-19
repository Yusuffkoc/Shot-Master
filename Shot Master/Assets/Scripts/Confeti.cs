using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Confeti : MonoBehaviour
{

    [SerializeField] private ParticleSystem[] _finishParticles;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach (var item in _finishParticles)
        {
            var emmision = item.emission;
            emmision.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            foreach (var item in _finishParticles)
            {
                var emmision = item.emission;
                emmision.enabled = true;
            }
        }
    }
}
