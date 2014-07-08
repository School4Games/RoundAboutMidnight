
using UnityEngine;
using System.Collections;

public class Loadingscreen : MonoBehaviour {
	private bool loading = true;
	
	public Texture loadingTexture;
	
	void Update () {
		if(Application.isLoadingLevel)
			loading = true;
		else
			loading = false;
	}
	
	void OnGUI () {
		if(loading)
			GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height), loadingTexture, ScaleMode.StretchToFill);
	}
}