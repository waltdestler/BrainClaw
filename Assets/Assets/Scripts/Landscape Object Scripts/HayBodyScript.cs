using UnityEngine;
using System.Collections;

public class HayBodyScript : MonoBehaviour {

	public ParticleSystem particles;
	public AudioSource sound;

	public GameObject spriteBody;

	bool isBeingEaten = false;

	float hayHealth = 1;
	const float timeToConsume = 3f;

	float maxYHayDistance = 0.6f;
	Vector3 spriteOrgPos;

	// Use this for initialization
	void Start () {
		
		spriteOrgPos = transform.position;
	}

	void Update()
	{
		//readjust height
		spriteBody.transform.position = spriteOrgPos - Vector3.up * (1- hayHealth) * maxYHayDistance;

		//Decide when to die
		if (hayHealth <= 0)
			gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (isBeingEaten) {
			//Deplete Health
			hayHealth -= Time.deltaTime * (1/timeToConsume);

			if(!particles.isPlaying)
				particles.Play ();

			if (sound != null && !sound.isPlaying)
				sound.Play();
		} 
		else 
		{
			particles.Stop ();

			if(sound != null && sound.isPlaying)
				sound.Stop();
		}

		//Restart variable
		isBeingEaten = false;
	}

	public void BeingEaten()
	{
		isBeingEaten = true;
	}
}
