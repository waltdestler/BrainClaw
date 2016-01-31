using UnityEngine;
using System.Collections;

using System.Collections.Generic;


public class AbductorBeam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    void OnTriggerEnter2D (Collider2D o) {
        var obody = o.gameObject.GetComponent<CharacterBody>();


        if (obody)
        {
			obody.gameObject.AddComponent<AlienAbduction> ();
            obody.animator.speed = 0;
            obody.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
