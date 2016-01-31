using UnityEngine;
using System.Collections;

using System.Collections.Generic;


public class AbductorBeam : MonoBehaviour {
	public ScoreKeeper scoreboardConnected;

	// Use this for initialization
	void Start () {
	}

    void OnTriggerEnter2D (Collider2D o) {
        var obody = o.gameObject.GetComponent<CharacterBody>();

        if (obody) {
			obody.gameObject.AddComponent<AlienAbduction> ();
			obody.animator.speed = 0;
			obody.enabled = false;
			scoreboardConnected.numLeftToAbduct -= 1;
			// Advance level if cleared.
			if (scoreboardConnected.numLeftToAbduct == 0) {
				Debug.Log("Quota Fulfilled!!");
				if (Application.loadedLevel != Application.levelCount - 1) {
					Application.LoadLevel (Application.loadedLevel + 1);
				}
			}
		}
    }
	
	// Update is called once per frame
	void Update () {
	}
}
