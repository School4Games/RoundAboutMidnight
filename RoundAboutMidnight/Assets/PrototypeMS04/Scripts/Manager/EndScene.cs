using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour {

	public static EndScene Instance; // unser script (Singleton)
	public bool CanControl = true; // neue variable 

	void Awake()
	{
		Instance = this;
	}


	void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Untagged"))
        {
			CanControl = false;
			StartCoroutine(WaitForShowEndscreen());
			// Nene das funktioniert ja er lädt ja die scene   
			Debug.Log("Nigger Come on"+CanControl);
        }
    }

	IEnumerator WaitForShowEndscreen()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel("menu");
	}
}
