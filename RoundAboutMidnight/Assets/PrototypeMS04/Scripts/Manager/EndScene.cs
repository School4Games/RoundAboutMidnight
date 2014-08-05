using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour {

	public static EndScene Instance; // unser script (Singleton)
	public bool CanControl = false; // neue variable 

	void Awake()
	{
		Instance = this;
	}


	void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") )
        {
			//CanControl = false;
			CharakterManger.Instance.Charaktersnum =2;
			CharakterManger.Instance.Controllof2 = false;
			CharakterManger.Instance.Waitforanimation = false;
			//StartCoroutine(WaitForShowEndscreen());
			// Nene das funktioniert ja er lädt ja die scene   
			Debug.Log("Nigger Come on"+CanControl);
		
		}
    }

	void LateUpdate(){
	

	}

	IEnumerator WaitForShowEndscreen()
	{
		yield return new WaitForSeconds(3);
	
	Application.LoadLevel("menu");
	}
}
