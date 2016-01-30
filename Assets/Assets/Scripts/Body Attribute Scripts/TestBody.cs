using UnityEngine;
using System.Collections;

public class TestBody : CharacterBody {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.LeftArrow)) {
			MoveLeft ();
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			MoveRight ();
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Jump ();
		}

	}
}
