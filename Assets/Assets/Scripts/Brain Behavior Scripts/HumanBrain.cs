using UnityEngine;
using System.Collections;

public class HumanBrain : BrainBehavior {

	public float jumpInterval = 3f;

	float timer = 0;

	public CharacterBody.Direction currentDirection = CharacterBody.Direction.LEFT;
	
	// ManualUpdate is called once per frame by CharacterBody
	override public void ManualUpdate () {


		//Check if we hit a wall, turn around if we do

		if (body.CheckDirectionCollision (currentDirection)) {
			currentDirection = (currentDirection == CharacterBody.Direction.LEFT) ? CharacterBody.Direction.RIGHT : CharacterBody.Direction.LEFT;
		}

		//Walk in current direction
		if (currentDirection == CharacterBody.Direction.LEFT)
			body.MoveLeft ();
		else if (currentDirection == CharacterBody.Direction.RIGHT)
			body.MoveRight ();
	}


}
