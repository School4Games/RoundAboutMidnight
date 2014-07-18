using UnityEngine;
using System.Collections;

public class showpath : MonoBehaviour {
	public Transform Goal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			Debug.DrawLine(this.transform.position,Goal.transform.position,Color.red);
		
	}
}
