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

    //Spieler Stats
    public string pName;
    public float pSpeed;
    public float pJumpSpeed;
	public bool CanControl;

    public bool IsGrounded(){
        // Befindet sich der Spieler auf einem anderen Objekt 
        // Wenn ja IsGrounded = true - Else (False)
        return Physics.Raycast(this.transform.position, -Vector3.up,this.collider.bounds.extents.y + 0.01f);
    }

    public void Update(){
        
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

