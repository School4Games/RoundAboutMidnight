using UnityEngine;
using System.Collections;

public class KranManager : MonoBehaviour {

	public GameObject Kranblock;
	public GameObject Goal;
	public bool Kranan = false;
	public GameObject Buttonkran;
	public GameObject Schalter;
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
	void OnTriggerEnter(Collider other){
		Debug.Log("Crash");
		if(other.gameObject.tag == "Player"){
			Schalter.transform.Rotate(Schalter.transform.rotation.x,-42f,Schalter.transform.rotation.z);
			Kranan = true;
			Debug.Log("Kran aktiv");
		}
	}
}
