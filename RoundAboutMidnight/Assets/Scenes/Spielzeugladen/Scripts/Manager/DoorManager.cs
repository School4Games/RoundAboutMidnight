using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

	public Transform Plattform;


	void OnTriggerEnter(Collider other){
		Rotator();
		Debug.Log("Got it");
	}
	void Rotator(){
		Plattform.transform.Rotate(0,0,10*Time.deltaTime);
	}
}
