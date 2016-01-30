using UnityEngine;
using System.Collections;

public class GroundCheckerScript : MonoBehaviour {

	public bool isGrounded = false;


	void OnTriggerStay2D(Collider2D c)
	{
		isGrounded = true;
	}


	void OnTriggerExit2D(Collider2D c)
	{
		isGrounded = false;
	}

}
