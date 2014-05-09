using UnityEngine;
using System.Collections;

public class EnableEnvironmentManager : MonoBehaviour {

    public MovementSystem moveSystem;
    public GameObject environmentDisplay;
    
    void Awake()
    {
        
    }
	void Update () {

	    if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            environmentDisplay.SetActive(!environmentDisplay.activeSelf);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            moveSystem.instantStop =! moveSystem.instantStop;
        }
	}
}
