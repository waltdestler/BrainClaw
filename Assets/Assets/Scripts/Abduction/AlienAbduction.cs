using UnityEngine;
using System.Collections;

public class AlienAbduction : MonoBehaviour {

	float xCenter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		var scale = gameObject.transform.localScale;
		scale.x *= .99f;
		scale.y *= .99f;
		gameObject.transform.Rotate (0, 0, 4f / (scale.x+.1f)); // todo fix rotation center
		gameObject.transform.localScale = scale;
		gameObject.transform.position += new Vector3 ((xCenter-gameObject.transform.position.x)*0.1f, .03f, 0);

		if (scale.x < .1) {
			gameObject.SetActive (false);
			// todo: tally abduction
		}
	}

	public void SetBeamCenter(Vector3 center)
	{
		xCenter = center.x;
	}
}
