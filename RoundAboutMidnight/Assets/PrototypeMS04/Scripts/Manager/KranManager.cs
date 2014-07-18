using UnityEngine;
using System.Collections;

public class KranManager : MonoBehaviour {

	public GameObject Kranblock;
	public GameObject Goal;
	public bool Kranan = false;
	public GameObject Buttonkran;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Kranan){
		if(Kranblock.transform.position.y <= Goal.transform.position.y){
		Kranblock.transform.Translate (Vector3.up*Time.deltaTime*0.1f);
			}
		}
	}
	void OnCollisionEnter(Collision col){
		Debug.Log("Crash");
		if(col.gameObject.tag == "Player"){
			Kranan = true;
			Debug.Log("Kran aktiv");
		}
	}
}
