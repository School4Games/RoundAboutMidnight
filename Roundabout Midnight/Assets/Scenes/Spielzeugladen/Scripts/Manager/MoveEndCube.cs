using UnityEngine;
using System.Collections;

public class MoveEndCube : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball 3")
        {
            if (CharacterSwitchManager.Instance.currentPlayer.name == "Ball 3")
            {
                transform.rigidbody.mass = 0.1f;
            }
        }
    }

    void Update()
    {
        if (CharacterSwitchManager.Instance.currentPlayer.name != "Ball 3" && transform.rigidbody.mass < 500f)
        {
            transform.rigidbody.mass = 500f;
        }
    }
}
