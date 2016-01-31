using UnityEngine;
using System.Collections;

public class toggleSwitch : MonoBehaviour {

	public GameObject doorConnected;
	// Use this for initialization
	void Start () {
	
	}
	
    void OnTriggerEnter2D (Collider2D player) {
		if (player.tag == "character") {
			// Flip object asset along x-axis. 
			var scale = gameObject.transform.localScale;
			scale.x *= -1;
			gameObject.transform.localScale = scale;
			// Open lift/open door... For now, just hide and show.
			doorConnected.SetActive (!doorConnected.activeSelf);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
