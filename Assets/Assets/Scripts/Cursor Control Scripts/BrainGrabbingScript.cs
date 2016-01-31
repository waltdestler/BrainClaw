using UnityEngine;
using System.Collections;

public class BrainGrabbingScript : MonoBehaviour {


	enum ClawState {EMPTY, GRABBED}

	static int cursorClickableLayer = (1 << LayerMask.NameToLayer("CursorClickable"));

	BrainBehavior tempBrain = null;

	public SpriteRenderer cursorBrainRender;
	public GameObject grabSoundPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//if clicked
		//Raycast with cursor area
		//Get body
		//Check if there's a brain
		//Insert brain,
		//If there's a brain switch with current one

		if (Input.GetMouseButtonDown (0)) {

			//raycast to see if it hits anything
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit2D hitInfo = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity, cursorClickableLayer);

			if (hitInfo.collider) {
				Debug.Log ("hitinfo body name: " + hitInfo.collider.transform.ToString());

				//Find the body
				CharacterBody body = hitInfo.collider.GetComponent<CharacterBody>();


				BrainBehavior backupTempBrain = null;

				bool playSound = false;

				//if the body has a brain, always take the brain
				if (body.brainBehavior) {
					body.brainBehavior.enabled = false;
					backupTempBrain = body.brainBehavior;
					body.brainBehavior = null;
					playSound = true;
				}

				//if we have a temp brain, always insert the brain
				if (tempBrain) {
					body.brainBehavior = tempBrain;
					tempBrain = null;
					body.brainBehavior.enabled = true;
					body.brainBehavior.body = body;
					cursorBrainRender.enabled = false;
					playSound = true;
				}

				//If we have a backup that we grabbed early, insert into claw
				if (backupTempBrain) {
					tempBrain = backupTempBrain;
					cursorBrainRender.enabled = true;
					cursorBrainRender.color = tempBrain.brainColor;
				}

				if (playSound && grabSoundPrefab != null)
				{
					Instantiate(grabSoundPrefab);
				}

			}
		}


		/*
		if (tempBrain == null) {
			cursorBrainRender.enabled = false;
		}
		else{
			cursorBrainRender.enabled = true;
			cursorBrainRender.color = tempBrain.brainColor;
		}*/
	}
}
