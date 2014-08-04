using UnityEngine;
using System.Collections;

public class Versobj : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "Player"){
		this.rigidbody.mass = 0.1f;
			this.rigidbody.angularDrag = 10;
		}else{
			this.rigidbody.mass = 5f;
		}
	}
}
