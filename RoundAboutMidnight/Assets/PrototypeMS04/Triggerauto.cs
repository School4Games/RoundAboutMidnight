using UnityEngine;
using System.Collections;

public class Triggerauto : MonoBehaviour {
	
	public GameObject Auto;
	public float Speed = 1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		Auto.transform.Translate(10*Time.deltaTime,0,0);

	}
}
