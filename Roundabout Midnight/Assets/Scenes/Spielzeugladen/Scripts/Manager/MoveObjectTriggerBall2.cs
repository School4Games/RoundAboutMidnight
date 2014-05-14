using UnityEngine;
using System.Collections;

public class MoveObjectTriggerBall2 : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball 2")
        {
           if(CharacterSwitchManager.Instance.currentPlayer.name == "Ball 2")
           {
               transform.rigidbody.mass = 0.1f;
           }
        }
    }
    
    void Update()
    {
        if(CharacterSwitchManager.Instance.currentPlayer.name == "Ball 1" && transform.rigidbody.mass < 500f)
        {
            transform.rigidbody.mass = 500f;
        }
    }
}
