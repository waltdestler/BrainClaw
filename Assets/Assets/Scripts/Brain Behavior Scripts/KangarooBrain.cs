using UnityEngine;
using System.Collections;

public class KangarooBrain : BrainBehavior {

	public float jumpInterval = 3f;

	float timer = 0;

	
	// ManualUpdate is called once per frame by CharacterBody
	override public void ManualUpdate () {
		
		timer += Time.deltaTime;

		//Determine when to jump
		if (timer > jumpInterval) 
		{
			timer -= jumpInterval;
			body.Jump ();
		}


	}


}
