using UnityEngine;
using System.Collections;

public class ActivateGameObject : MonoBehaviour {

	public void Deactivate()
	{
		gameObject.SetActive (false);
	}

	public void Activate()
	{
		gameObject.SetActive (true);
	}
}
