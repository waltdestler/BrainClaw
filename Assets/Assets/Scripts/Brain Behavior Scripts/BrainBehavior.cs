using UnityEngine;
using System.Collections;

public class BrainBehavior : MonoBehaviour {

	public CharacterBody body;

	// Use this for initialization
	void Start () {
	
	}



	virtual public void ManualUpdate() {
	
	}

	public void SetBody(CharacterBody newBody)
	{
		body = newBody;
	}
}
