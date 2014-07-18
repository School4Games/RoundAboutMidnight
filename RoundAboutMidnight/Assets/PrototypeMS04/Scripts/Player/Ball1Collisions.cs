using UnityEngine;
using System.Collections;

public class Ball1Collisions : MonoBehaviour {

    public Transform car;
    public Transform endcarpoint;
    public bool movecar = false;
	public int Selfdes;

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("control")){
            movecar = true;
        }
    }
    void FixedUpdate()
    {
        if(movecar){
            car.transform.position = Vector3.Lerp(car.transform.position, endcarpoint.transform.position, Time.deltaTime * 0.7f);
            // movecarobject.rigidbody.mass = 0.01f;
			Destroy(this,5f);


        }
    }
}
