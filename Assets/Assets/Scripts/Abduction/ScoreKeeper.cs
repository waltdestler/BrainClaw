using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public int numLeftToAbduct = 3;
    public bool showText = true;
	public Color textColor = Color.cyan;
	private Rect textArea;
	private GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
		textArea = new Rect(0,0, Screen.width, Screen.height);
		style.fontSize = 20;
		style.normal.textColor = textColor;
		style.font = (Font)Resources.Load("slkscr");
	}

    void OnGUI() {
		var textDisplay = "Abduction Quota: " + numLeftToAbduct;
        GUI.Label(textArea,textDisplay, style);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
