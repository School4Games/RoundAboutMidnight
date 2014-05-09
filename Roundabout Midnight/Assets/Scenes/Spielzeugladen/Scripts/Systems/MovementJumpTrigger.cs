using UnityEngine;
using System.Collections;

public class MovementJumpTrigger : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "BallJumpTrigger" && !MovementSystem.Instance.IsGrounded())
        {
            if(transform.position.y > other.transform.position.y)
                CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.AddForce(0, 350, 0); 
        }
    }
}
