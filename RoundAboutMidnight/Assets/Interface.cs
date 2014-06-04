using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	public GUIStyle boxstyle;
	public GUIStyle background;

	// Use this for initialization
	void Start () {

	
	}
	void OnGUI (){
		GUI.Box (new Rect (Screen.width /2  - 960 , Screen.height / 2 - 540, 1920, 1080), "Test", background);
		GUI.Box (new Rect (Screen.width / 2 - 225, Screen.height / 2 - 250, 450, 450), "");
		GUI.Label (new Rect (Screen.width / 2 - 225, Screen.height / 2 - 250, 450, 450), "Menu",boxstyle);
		if (GUI.Button (new Rect (Screen.width / 2 - 75, Screen.height / 2 - 150, 150, 50), "Start")) {
            Application.LoadLevel("Spielzeugladen");
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 75, Screen.height / 2 - 50, 150, 50), "Option")) {
			Debug.Log("Option Button");	
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 75, Screen.height / 2 + 50, 150, 50), "Credits"))
		{
			Debug.Log("Credits Button");
		}

	}



	// Update is called once per frame
	void Update () {
	
	}
}
