using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
    public bool showText = true;
    public Rect textArea = new Rect(0,0,Screen.width, Screen.height);


	// Use this for initialization
	void Start () {
        
	}

    void OnGUI() {
        GUI.Label(textArea,"Test of text display");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
