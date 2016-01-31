using UnityEngine;
using System.Collections;

using System.Collections.Generic;


public class AlienAbductor : MonoBehaviour {

    private List<GameObject> abducting;

	// Use this for initialization
	void Start () {
        abducting = new List<GameObject>();
	}

    void OnTriggerEnter2D (Collider2D o) {
        var obody = o.gameObject.GetComponent<CharacterBody>();
        if (obody)
        {
            obody.animator.speed = 0;
            obody.enabled = false;
            if (o.gameObject.transform.parent != gameObject.transform)
                abducting.Add(o.gameObject);
                o.gameObject.transform.parent = gameObject.transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject g in abducting)
        {
        }
	}
}
