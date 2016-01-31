using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public int numAbducted = 0;
    public bool showText = true;
    public Rect textArea = new Rect(0,0,Screen.width, Screen.height);

	// Use this for initialization
	void Start () {
        
	}
		
    void OnGUI() {
		var textDisplay = "Abducted: " + numAbducted;
        GUI.Label(textArea,textDisplay);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
