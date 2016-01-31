using UnityEngine;
using System.Collections;

using System.Collections.Generic;


public class AbductorBeam : MonoBehaviour {
	public ScoreKeeper scoreboardConnected;
	float nextLevelDelay = 2.5F;
	public GameObject soundPrefab;

	// Use this for initialization
	void Start () {
	}

    void OnTriggerEnter2D (Collider2D o) {
        var obody = o.gameObject.GetComponent<CharacterBody>();

        if (obody) {
			obody.gameObject.AddComponent<AlienAbduction> ();
			obody.gameObject.GetComponent<AlienAbduction> ().SetBeamCenter (transform.position);
            obody.animator.SetBool("jumping", true);
			obody.enabled = false;
	        if (soundPrefab != null)
		        Instantiate(soundPrefab);
			scoreboardConnected.numLeftToAbduct -= 1;
			// Advance level if cleared.
			if (scoreboardConnected.numLeftToAbduct == 0) {
				Debug.Log("Quota Fulfilled!!");
				StartCoroutine(GotoNextLevel());
			}
		}
    }

	IEnumerator GotoNextLevel()
	{
		yield return new WaitForSeconds(nextLevelDelay);
		if (Application.loadedLevel != Application.levelCount - 1) {
			Application.LoadLevel ((Application.loadedLevel + 1)%Application.levelCount);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
