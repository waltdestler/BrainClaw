using UnityEngine;
using System.Collections;

public class CowBrain : BrainBehavior {

	public float jumpInterval = 3f;

	float timer = 0;

	static int grassOnlyLayer = (1 << LayerMask.NameToLayer("Grass"));

	public float raycastDistance = 10f;

	public float stopDistance = 0.3f;

	// ManualUpdate is called once per frame by CharacterBody
	override public void ManualUpdate () {

		//Shoot a raycast to either side and find closest grass
		Transform closestGrass = FindClosestGrass();

		if (!closestGrass)
			return;

		//Check if we are close enough already. If not, move towards the direction
		if (Vector2.Distance (closestGrass.position, body.transform.position) > stopDistance) {

			if (closestGrass.position.x - transform.position.x > 0)
				body.MoveRight ();
			else
				body.MoveLeft ();
		}
		
	}

	//return null if non exist
	Transform FindClosestGrass()
	{
		Vector2 bodyPosition = new Vector2(body.transform.position.x, body.transform.position.y);

		RaycastHit2D rightHitInfo = Physics2D.Raycast (bodyPosition,Vector2.right, raycastDistance, grassOnlyLayer);
		RaycastHit2D leftHitInfo = Physics2D.Raycast (bodyPosition, Vector2.left, raycastDistance, grassOnlyLayer);

		if (rightHitInfo.collider != null) {

			//if both directions hit, find the closest
			if (leftHitInfo.collider != null) {

				if (leftHitInfo.distance < rightHitInfo.distance) {
					return leftHitInfo.collider.transform;
				} else {
					return rightHitInfo.collider.transform;
				}

			}

			return rightHitInfo.collider.transform;
		}

		if (leftHitInfo.collider != null)
			return leftHitInfo.collider.transform;


		return null;
	}


	void OnDrawGizmos()
	{
		
		Vector3 bodyPosition = body.transform.position;
		Gizmos.color = Color.red;
		Gizmos.DrawLine (bodyPosition, bodyPosition + transform.right * raycastDistance);
		Gizmos.color = Color.grey;
		Gizmos.DrawLine (bodyPosition, bodyPosition - transform.right * raycastDistance);
	}

}
