using UnityEngine;
using System.Collections;

public class toggleSwitch : MonoBehaviour {

	public GameObject doorConnected;
	public Vector3 openTranslate;
	// Use this for initialization
	void Start () {
	
	}
	
    void OnTriggerEnter2D (Collider2D player) {
        var obody = player.gameObject.GetComponent<CharacterBody>();

        if (obody)
        {
            // Flip object asset along x-axis. 
            var scale = gameObject.transform.localScale;
            scale.x *= -1;
            gameObject.transform.localScale = scale;
            // Open lift/open door... For now, just hide and show.
//            doorConnected.SetActive(!doorConnected.activeSelf);
			float direction = -Mathf.Sign(scale.x);
			doorConnected.transform.Translate(openTranslate*direction);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
