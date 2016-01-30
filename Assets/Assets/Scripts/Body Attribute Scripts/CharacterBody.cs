using UnityEngine;
using System.Collections;

public class CharacterBody : MonoBehaviour {

	public float moveSpeed = 1f;
	public float jumpHeight = 1f;
	public float jumpTime = 1f;
	public float fallSpeed = 1f;
	public enum Direction {LEFT, RIGHT, UP, DOWN}
	Direction sideFacing = Direction.LEFT;

	private bool isJumping = false;

	public BrainBehavior brainBehavior;

	public CollisionManager collisionManager;

	public Animator animator;

	// Use this for initialization
	void Start () 
	{
		
	}


	void Update()
	{
		if(animator)
			animator.SetFloat("walk_speed", 0);

		if (brainBehavior != null) 
		{
			brainBehavior.ManualUpdate ();
		}

		if (!collisionManager.BotIsColliding()) 
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
		if (collisionManager.BotIsColliding() &&
			!collisionManager.LeftIsColliding()) 
		{
			sideFacing = Direction.LEFT;

			//GetComponent<Rigidbody2D> ().MovePosition (transform.position -moveSpeed * Time.deltaTime * transform.right );
			transform.Translate (-moveSpeed * Time.deltaTime * transform.right);

			if (animator) 
			{
				animator.SetFloat ("walk_speed", moveSpeed);
				animator.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}

	public virtual void MoveRight()
	{
		if (collisionManager.BotIsColliding() &&
			!collisionManager.RightIsColliding()) 
		{
			sideFacing = Direction.RIGHT;

			transform.Translate (moveSpeed * Time.deltaTime * transform.right);

			if (animator) 
			{
				animator.SetFloat ("walk_speed", moveSpeed);
				animator.transform.localScale = new Vector3 (-1, 1, 1);
			}
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
		if (isJumping || !collisionManager.BotIsColliding()) {
			yield break;
		}

		isJumping = true;

		float currentHeight = transform.position.y;

		while( transform.position.y < currentHeight+jumpHeight)
		{

			if (collisionManager.TopIsColliding ())
				break;	

			transform.Translate (jumpHeight / jumpTime * Time.deltaTime * transform.up);
			yield return null;
		}


		isJumping = false;
			
	}
		
	public bool CheckDirectionCollision(Direction d)
	{
		return collisionManager.directionColliding (d);
	}
}
