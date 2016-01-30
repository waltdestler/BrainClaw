using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

	public CollisionChecker bot;
	public CollisionChecker top;
	public CollisionChecker left;
	public CollisionChecker right;


	public bool directionColliding(CharacterBody.Direction dir)
	{
		if (dir == CharacterBody.Direction.LEFT)
			return LeftIsColliding ();
		else if (dir == CharacterBody.Direction.RIGHT)
			return RightIsColliding ();
		else if (dir == CharacterBody.Direction.UP)
			return TopIsColliding ();
		else
			return BotIsColliding ();
			
	}


	public bool RightIsColliding()
	{
		return right.isColliding;
	}

	public bool LeftIsColliding()
	{
		return left.isColliding;
	}

	public bool TopIsColliding()
	{
		return top.isColliding;
	}

	public bool BotIsColliding()
	{
		return bot.isColliding;
	}
}
