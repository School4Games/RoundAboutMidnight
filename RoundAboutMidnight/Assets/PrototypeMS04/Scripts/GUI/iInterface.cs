using UnityEngine;
using System.Collections;

public class iInterface : MonoBehaviour {

	public GUIStyle questbanner;
	public int questbannertimer;
	public bool displayquestbanner;
	public bool displayedquestbanner;

	void Update()
    {
		if(CamerIntro.Instance.displayIntroText == false && !displayedquestbanner)
		{
			displayedquestbanner = true;
			StartCoroutine(QuestDisplayTimer());
		}
    }

	void OnGUI()
	{
		if(displayquestbanner)
		{
			GUI.Box(new Rect(Screen.width /2 - 450, Screen.height - 120, 900, 120),"Befreie den Baseball",questbanner);
		}
	}

	IEnumerator QuestDisplayTimer()
	{
		//Display 
		displayquestbanner = true;
		yield return new WaitForSeconds(questbannertimer); 
		displayquestbanner = false;
		//Enddisplay
	}
}
