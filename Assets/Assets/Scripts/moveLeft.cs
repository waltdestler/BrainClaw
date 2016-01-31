using UnityEngine;
using System.Collections;

public class moveLeft : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (-0.1f, 0, 0);
	}
}
