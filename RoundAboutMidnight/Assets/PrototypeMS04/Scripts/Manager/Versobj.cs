using UnityEngine;
using System.Collections;

public class Versobj : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "Baseball"){
		this.rigidbody.mass = 0.01f;
			this.rigidbody.angularDrag = 10;
		}else{
			this.rigidbody.mass = 5f;
		}
	}
	void OnCollisionExit(Collision collisionInfo){
			if(collisionInfo.transform.tag == "Baseball"){
			this.rigidbody.mass = 5;
			}
		}

	}

