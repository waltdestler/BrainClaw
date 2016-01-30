using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

	public CollisionChecker bot;
	public CollisionChecker top;
	public CollisionChecker left;
	public CollisionChecker right;

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
