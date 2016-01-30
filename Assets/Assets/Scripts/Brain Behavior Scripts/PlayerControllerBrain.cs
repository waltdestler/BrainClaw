using UnityEngine;
using System.Collections;

public class PlayerControllerBrain : BrainBehavior {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	override public void ManualUpdate () {
		
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
