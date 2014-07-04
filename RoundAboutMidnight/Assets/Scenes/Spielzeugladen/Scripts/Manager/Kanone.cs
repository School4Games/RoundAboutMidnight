using UnityEngine;
using System.Collections;

public class Kanone : MonoBehaviour {
	public Transform Abschussort;

	
	// Update is called once per frame
	void  OnTriggerEnter(Collider other) {
		if(other.tag == "Leuchtball"){
			other.transform.position = Abschussort.position;
			other.rigidbody.AddForce(10,200,0);
		}

	
	}
}
