using UnityEngine;
using System.Collections;

public class toggleSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnTriggerEnter2D (Collider2D player) {
        var scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
