using UnityEngine;
using System.Collections;

public class HumanBrain : BrainBehavior {

	public float jumpInterval = 3f;

	float timer = 0;

	
	// ManualUpdate is called once per frame by CharacterBody
	override public void ManualUpdate () {
		
		//Walk in one direction until you hit a wall
		//Then turn around

	}


}
