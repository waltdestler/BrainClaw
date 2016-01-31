using UnityEngine;
using System.Collections;

public class AlienAbduction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		var scale = gameObject.transform.localScale;
		scale.x *= .95f;
		scale.y *= .95f;
		gameObject.transform.Rotate (0, 0, 4f / (scale.x+.1f)); // todo fix rotation center
		gameObject.transform.localScale = scale;
		gameObject.transform.position += new Vector3 (0, .1f, 0);

		if (scale.x < .1) {
			gameObject.SetActive (false);
			// todo: tally abduction
		}
	}
}
