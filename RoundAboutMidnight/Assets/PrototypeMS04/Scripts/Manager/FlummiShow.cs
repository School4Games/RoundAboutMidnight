using UnityEngine;
using System.Collections;

public class FlummiShow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "control"){
			this.GetComponent<Movement>().CanControl = false;
		}
	}
}
