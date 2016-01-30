using UnityEngine;
using System.Collections;

public class CollisionChecker : MonoBehaviour {

	public bool isColliding = false;


	void OnTriggerStay2D(Collider2D c)
	{
		isColliding = true;
	}


	void OnTriggerExit2D(Collider2D c)
	{
		isColliding = false;
	}

}
