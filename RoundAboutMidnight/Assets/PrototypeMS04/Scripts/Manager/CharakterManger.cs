using UnityEngine;
using System.Collections;

public class CharakterManger : MonoBehaviour {

	public static CharakterManger Instance;
	public bool Controllof2;
	public int Charaktersnum;
	public bool Baseavabile;
	public GameObject Player1;
	public GameObject Player2;
	public bool Waitforanimation;
	// Use this for initialization
	void Awake() {
		 Instance = this;
		Charaktersnum = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Controllof2){
		if(Input.GetKeyDown("e")){
			Charaktersnum += 1;
		}
		if(Input.GetKeyDown("q")){
			Charaktersnum -= 1;
		}
		}
		if(Waitforanimation){
			Switcher();
		}
	}


	void Switcher(){
		if(Charaktersnum == 1){
			Player1.GetComponent<Movement>().enabled = true;
			CameraSystem.Instance.cTarget = Player1.transform;

			Player2.GetComponent<Movement>().enabled = false;
			//Player 1
		}

		if(Charaktersnum == 2 && Baseavabile){
			Player1.GetComponent<Movement>().enabled = false;


			Player2.GetComponent<Movement>().enabled = true;
			CameraSystem.Instance.cTarget = Player2.transform;
			//Player 2
		}

		if(Charaktersnum >= 3){
			Charaktersnum = 1;
		}
		if(Charaktersnum <= 0){
			Charaktersnum = 2;
		}
	}
}
