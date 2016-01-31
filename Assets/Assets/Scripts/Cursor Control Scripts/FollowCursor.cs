using UnityEngine;
using System.Collections;

public class FollowCursor : MonoBehaviour {

	void Start()
	{
		Cursor.visible = false;
	}

	
	// Update is called once per frame
	void LateUpdate () {
	

		Vector3 mosToWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		mosToWorld.z = 0;

		transform.position = mosToWorld;
	}
}
