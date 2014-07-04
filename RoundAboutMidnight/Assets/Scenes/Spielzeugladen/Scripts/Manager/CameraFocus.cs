using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {

	public GameObject Target;
	private Vector3 Posi;
	// Update is called once per frame
	void Update () {
		Posi = Target.transform.position;
		this.transform.position =new Vector3(Posi.x,Posi.y,this.transform.position.z);
	
	}
}
