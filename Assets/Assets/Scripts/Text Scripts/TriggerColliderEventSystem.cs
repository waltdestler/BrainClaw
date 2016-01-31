using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TriggerColliderEventSystem : MonoBehaviour {

	public UnityEvent tiggerEvent;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject == target) {
			tiggerEvent.Invoke ();
		}
	}
}

