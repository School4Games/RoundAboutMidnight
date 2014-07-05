using UnityEngine;
using System.Collections;

public class Ball1Collisions : MonoBehaviour {

    public Transform car;

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("control"))
        {
            Debug.Log("Funktioniert");
            car.transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
