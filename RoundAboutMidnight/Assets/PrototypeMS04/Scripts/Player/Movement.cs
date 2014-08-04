/*
 * 
 *  Auf jeden Spieler bzw. auf jeden unserer Bälle muss das Movement Script angehangen werden
 *  Achte bitte darauf das auf dem Managerobjekt in der Scene auch jeweils die Anzahl an Bälle 
 *  vorhanden sind wie auch Bälle im Spiel sein sollen
 *  
 *  Außerdem muss für jeden Ball (Ball1Collisions) für Ball 1 noch hinzugefügt werden.
 * 
 * */

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public static Movement Instance;

    //Spieler Stats
    public string pName;
    public float pSpeed;
    public float pJumpSpeed;
	public bool CanControl;
	public Camera introCamera;
	public GameObject Auto;
	public float Raylenght;
	private Rigidbody rb;



    public bool IsGrounded(){
        // Befindet sich der Spieler auf einem anderen Objekt 
        // Wenn ja IsGrounded = true - Else (False)
        return Physics.Raycast(this.transform.position, -Vector3.up,this.collider.bounds.extents.y + Raylenght);
    }

	void Awake()
	{
		if(this.transform.tag == "Baseball"){
			Raylenght = 0.05f;
		}

		Instance = this;
	}

    public void Update(){
		introCamera = GameObject.Find("c1Intro").camera;
		Auto = GameObject.FindGameObjectWithTag("Auto");

		if(gameObject.rigidbody == null){
		rb = gameObject.AddComponent("Rigidbody") as Rigidbody;
		//Add rigidbody if it not exits
			Debug.Log("Success");
		}

		if(this.tag == "Baseball"){
			pSpeed = 8f;
			pJumpSpeed = 1.2f;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionZ; 
		}

	Physics.IgnoreCollision(this.collider,Auto.collider);



		if(EndScene.Instance.CanControl == false) // Update methode ( singleton)
		{
			CanControl = false; // movement = false
			return;
		}
		if(introCamera.enabled == true){
			CanControl = false;
		}else{
			CanControl = true;
		}
    }

    public void FixedUpdate(){
	


		if(CanControl){
        //Abfragen ob die taste D oder RightArrow gedrückt werden
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            //Wenn ja dann den Spieler nach rechts bewegen
            this.rigidbody.AddForce(Vector3.right * pSpeed * Time.deltaTime);
        }

        //Abfragen ob die taste A oder LeftArrow gedrückt werden
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            // Wenn ja dann den Spieler nach Links bewegen
            this.rigidbody.AddForce(Vector3.right * -pSpeed * Time.deltaTime);
        }

        //Wenn der Spieler sich auf dem Boden befindet dann
        if (IsGrounded()){
            //Wenn der Spieler sich auf dem Boden befindet und Space Taste betätigt
            if (Input.GetKey(KeyCode.Space)){
                //Dann verändert sich der Y Wert des Spielers
                this.rigidbody.velocity = new Vector3(0, pJumpSpeed, 0);
            }
        }

    }
}
}

