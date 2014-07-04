using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float Speed;
	public float Jumppw;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("d")){
			this.rigidbody.AddForce(Speed,0,0);
		}
		if(Input.GetKeyDown("a")){
			this.rigidbody.AddForce(-Speed,0,0);
		}
		if(Input.GetKeyDown("w")){
			this.rigidbody.AddForce(0,Jumppw,0);
		}
	
	}
}
