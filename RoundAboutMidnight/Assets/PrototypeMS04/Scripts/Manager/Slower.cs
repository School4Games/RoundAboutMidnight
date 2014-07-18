using UnityEngine;
using System.Collections;

public class Slower : MonoBehaviour {
	public float Damping;
	public float Count;
	public GameObject Baseball;
	private bool GotComponent = false;
	private GameObject Startposbb;
	public GameObject Manager;
	// Use this for initialization
	void Start () {
		Startposbb = GameObject.FindWithTag("bbstart");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" && Count == 0){
			Count += 1;
		other.rigidbody.AddForce(0,Damping,0);
			Debug.Log(Count);
		}
		if(other.tag == "Baseball" && GotComponent == false){
			Manager.GetComponent<CharakterManger>().Baseavabile = true;
			Baseball.AddComponent<Movement>();
			Baseball.GetComponent<Movement>().enabled = false;;
			GotComponent = true;
			Debug.Log("Baseball aktiv");
			Baseball.transform.position = Startposbb.transform.position;
		}
	}
}
