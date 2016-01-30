using UnityEngine;
using System.Collections;

public class PlayerControllerBrain : BrainBehavior {

	public CharacterBody body;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			body.MoveLeft ();
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			body.MoveRight ();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			body.Jump ();
		}

	}
}
