using UnityEngine;
using System.Collections;

public class CharacterBody : MonoBehaviour {

	public float moveSpeed = 1f;
	public float jumpHeight = 1f;
	public float jumpTime = 1f;
	public float fallSpeed = 1f;
	public enum Direction {LEFT, RIGHT}

	private bool isJumping = false;

	public BrainBehavior brainBehavior;

	public GroundCheckerScript groundCheckerScript;

	public Animator animator;

	// Use this for initialization
	void Start () 
	{
		
	}


	void Update()
	{
		animator.SetFloat("walk_speed", 0);

		if (brainBehavior != null) 
		{
			brainBehavior.ManualUpdate ();
		}

		if (!groundCheckerScript.isGrounded) 
		{
			// Check if we are jumping
			if (!isJumping) 
			{
				Fall ();
			}
		}
	}

	public virtual void MoveLeft()
	{
		if (groundCheckerScript.isGrounded) 
		{
			//GetComponent<Rigidbody2D> ().MovePosition (transform.position -moveSpeed * Time.deltaTime * transform.right );
			transform.Translate (-moveSpeed * Time.deltaTime * transform.right);

			animator.SetFloat("walk_speed", moveSpeed);
			animator.transform.localScale = new Vector3(1, 1, 1);
		}
	}

	public virtual void MoveRight()
	{
		if (groundCheckerScript.isGrounded) 
		{
			transform.Translate (moveSpeed * Time.deltaTime * transform.right);

			animator.SetFloat("walk_speed", moveSpeed);
			animator.transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	public virtual void Jump()
	{
		//Check if on ground
		StartCoroutine(JumpingCoroutine());
	}

	public virtual void Fall()
	{
		transform.Translate (-fallSpeed * Time.deltaTime * transform.up);
	}

	IEnumerator JumpingCoroutine()
	{
		if (isJumping || !groundCheckerScript.isGrounded) {
			yield break;
		}

		isJumping = true;

		float currentHeight = transform.position.y;

		while( transform.position.y < currentHeight+jumpHeight)
		{
			transform.Translate (jumpHeight/jumpTime * Time.deltaTime * transform.up);
			yield return null;
		}


		isJumping = false;
			
	}



}
