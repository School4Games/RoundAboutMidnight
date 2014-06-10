using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	public GUIStyle boxstyle;
	public GUIStyle background;
    public GUIStyle btnStart;
    public GUIStyle btnClosed;
    public GUIStyle btnSettings;

	void OnGUI (){

		GUI.Box (new Rect (Screen.width /2 - Screen.width/2 , Screen.height / 2 - Screen.height /2 , Screen.width, Screen.height), "", background);

        if (GUI.Button(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 75, 280, 100), "", btnStart)) 
        {
            Application.LoadLevel("Spielzeugladen");
		}
        if (GUI.Button(new Rect(Screen.width / 2 - 120, Screen.height / 2 + 13, 280, 100), "", btnClosed))
        {
			Debug.Log("Option Button");	
		}
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 280, 100), "", btnSettings))
		{
			Debug.Log("Credits Button");
		}

	}

}
