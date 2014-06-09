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

        if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 150, 150, 50), "", btnStart)) 
        {
            Application.LoadLevel("Spielzeugladen");
		}
        if (GUI.Button(new Rect(Screen.width / 2 - 55, Screen.height / 2 - 50, 150, 50), "", btnClosed))
        {
			Debug.Log("Option Button");	
		}
        if (GUI.Button(new Rect(Screen.width / 2 - 35, Screen.height / 2 + 50, 150, 50), "", btnSettings))
		{
			Debug.Log("Credits Button");
		}

	}

}
