using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
