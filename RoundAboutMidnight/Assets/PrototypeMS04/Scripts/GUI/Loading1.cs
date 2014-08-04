using UnityEngine;
using System.Collections;

public class Loading1 : MonoBehaviour {
	

	void OnGUI(){
		if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
			Debug.Log("Button Clicked");
		Application.LoadLevel("Vordergrund");
//	FindObjectOfType<LevelManager>().Onlevelend;
	}
}
