using UnityEngine;
using System.Collections;

public class Collision_Manager : MonoBehaviour {

    public static Collision_Manager Instance;

    public GameObject moveObjectCubeBall2;
    public GameObject moveObjectCubeBall3;


    void Awake()
    {
        Instance = this;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Trampolin")
        {
            if (TrampolinManager.Instance.activetrampoline)
            {
                CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity = new Vector3(CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity.x, 8);
                Debug.Log("Test1");
            }
            Debug.Log("Test2");
        }

        if (other.gameObject.name == "moveObjectBall2")
        {
            if (CharacterSwitchManager.Instance.currentPlayer.name == "Ball 2")
            {
                moveObjectCubeBall2.transform.rigidbody.mass = 0.1f;
                Debug.Log("1");
            }
        }

        if (other.gameObject.name == "moveObjectBall3")
        {
            if (CharacterSwitchManager.Instance.currentPlayer.name == "Ball 3")
            {
                moveObjectCubeBall3.transform.rigidbody.mass = 0.1f;
            }
        }
    }

    void Update()
    {
        if (CharacterSwitchManager.Instance.currentPlayer.name == "Ball 1" && moveObjectCubeBall2.transform.rigidbody.mass < 500f)
        {
            moveObjectCubeBall2.transform.rigidbody.mass = 500f;
        }
        if (CharacterSwitchManager.Instance.currentPlayer.name != "Ball 3" && moveObjectCubeBall2.transform.rigidbody.mass < 500f)
        {
            moveObjectCubeBall3.transform.rigidbody.mass = 500f;
        }
    }
}
