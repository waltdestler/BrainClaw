using UnityEngine;
using System.Collections;

public class CollisionChecker : MonoBehaviour {

	public bool isColliding 
    {
        get {
            return gameObject.GetComponent<Collider2D>().IsTouchingLayers(~4);
        }
    }

}
