using UnityEngine;
using System.Collections;

public class CharacterBody : MonoBehaviour {

	public float moveSpeed = 1f;
	public float jumpHeight = 1f;
	public float jumpTime = 1f;
	public float fallSpeed = 0f;

	public enum Direction {LEFT, RIGHT, UP, DOWN}
	Direction sideFacing = Direction.LEFT;

	private bool isJumping = false;

	public BrainBehavior brainBehavior;

	public CollisionManager collisionManager;

	public Animator animator;
	public GameObject jumpSoundPrefab;

	// Use this for initialization
	void Start () 
	{
        fallSpeed = 0;
	}


	void Update()
	{
		if(animator)
			animator.SetFloat("walk_speed", 0);

		if (brainBehavior != null && brainBehavior.enabled) 
		{
			brainBehavior.ManualUpdate ();
		}

        bool botColliding = collisionManager.BotIsColliding();
        Fall (botColliding);
        if (animator)
            animator.SetBool("jumping", !botColliding);
		
	}

	public virtual void MoveLeft()
	{
		if (collisionManager.BotIsColliding() &&
			!collisionManager.LeftIsColliding()) 
		{
			sideFacing = Direction.LEFT;

//			Debug.Log ("Moving Left");

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

			Debug.Log ("Moving Right");

			transform.Translate (moveSpeed * Time.deltaTime * transform.right);

			if (animator) 
			{
				animator.SetFloat ("walk_speed", moveSpeed);
				animator.transform.localScale = new Vector3 (-1, 1, 1);
			}
		}
	}

	public void Jump()
	{
        if (isJumping || !collisionManager.BotIsColliding()) {
            return;
        }

        isJumping = false;

        float currentHeight = transform.position.y;
        float jumpFallSpeed = -6.0f;

        fallSpeed = jumpFallSpeed;

		if (jumpSoundPrefab != null)
			Instantiate(jumpSoundPrefab);
	}

    public void Fall(bool botColliding)
	{
        float maxFallSpeed = 10f;
        float fallSpeedAccel = 10f;
        float changeFallSpeed = fallSpeedAccel * Time.deltaTime;
        if (fallSpeed + changeFallSpeed > maxFallSpeed) {
            changeFallSpeed = maxFallSpeed - fallSpeed;
        }

        float deltaY = -(fallSpeed + .5f * changeFallSpeed);
        float collidingFactor = 1;
        if (deltaY > 0 && collisionManager.TopIsColliding())
            collidingFactor = 0;
        if (deltaY < 0 && botColliding)
            collidingFactor = 0;
        
        deltaY *= collidingFactor;

        float safeRange = .2f;
        float stepY = Mathf.Clamp(deltaY * Time.deltaTime, -safeRange, safeRange);
        GetComponent<Rigidbody2D> ().MovePosition (transform.position + stepY * transform.up );

        fallSpeed += changeFallSpeed;
        fallSpeed *= collidingFactor;

	}
		
	public bool CheckDirectionCollision(Direction d)
	{
		return collisionManager.directionColliding (d);
	}
}
