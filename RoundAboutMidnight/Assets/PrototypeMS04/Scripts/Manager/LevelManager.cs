using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	//Singleton
	private static LevelManager _instance; 
	public bool Level1Compl;
	private int Shown;
	void Awake(){
		DontDestroyOnLoad(this);
	}

	public static LevelManager GetInstance(){
		//if not _instance kreiere ein neues GameObject das in _instance geadded wird
		if (!_instance) {

			_instance = GameObject.FindObjectOfType(typeof(LevelManager)) as LevelManager;
			
		}
		Debug.Log("xxx");
		return _instance;
	}
	void Start () {
	
	}

	public void Lvl1complete(){
		Level1Compl = true;
	}

	void Update (){ 
		if(Input.GetMouseButtonDown(1)){
			Application.LoadLevel("MS04_Prototyp");
		}
		if(Input.GetKeyDown("1")){
			Application.LoadLevel("Vordergrund");
		}
		Loadingscreen();
		Onlevelend();

	}

	void Loadingscreen(){
		if(Level1Compl && Shown == 1){
			Application.LoadLevel("Loadingscreen1-2");
		}
	}
	

		public void Onlevelend(){
				Shown += 1;

		}



	}


	






