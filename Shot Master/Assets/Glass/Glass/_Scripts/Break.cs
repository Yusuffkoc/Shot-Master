using UnityEngine;
using System.Collections;

public class Break : MonoBehaviour 
{
	public Transform brokenObject;
	public float magnitudeCol, radius, power, upwards;
	//benim eklediklerim
	public AudioClip sound;
	[Range(1, 6)]  public float  SoundVolume;
	//
	void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude > magnitudeCol)
		{
			//benim eklediklerim

			AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, SoundVolume);

			//
			Destroy(gameObject);
			Instantiate(brokenObject, transform.position, transform.rotation);
			brokenObject.localScale = transform.localScale;
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);

			foreach (Collider hit in colliders)
			{
				if (hit.GetComponent<Rigidbody>())
				{
					hit.GetComponent<Rigidbody>().AddExplosionForce(power*collision.relativeVelocity.magnitude, explosionPos, radius, upwards);
				}
			}
		}
	}
}
