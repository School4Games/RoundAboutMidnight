using UnityEngine;
using System.Collections;

public class Collision_Manager : MonoBehaviour {

    public static Collision_Manager Instance;

    public GameObject moveObjectCubeBall2;
    public GameObject moveObjectCubeBall3;

    public GameObject moveCarObjectSmall;
    //  GameObject moveCarObjectBig;

    public GameObject moveBridge;
    public GameObject moveBrdigeClosed;
    public GameObject moveBridgeOpen;

    public bool pressed;



    void Awake()
    {
        Instance = this;

        moveBridge.transform.position = moveBrdigeClosed.transform.position;
        moveBridge.transform.rotation = moveBrdigeClosed.transform.rotation;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "objectDruckPlatte")
        {
            if (CharacterSwitchManager.Instance.currentPlayer.name != "Ball 1")
            {
                moveBridge.transform.position = moveBrdigeClosed.transform.position;
                moveBridge.transform.rotation = moveBrdigeClosed.transform.rotation;
                pressed = false;
            }
            Debug.Log("Test2");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Trampolin")
        {

            CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity = new Vector3(CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity.x, 12);
            Debug.Log("Test1");
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

        if (other.gameObject.name == "Car_small")
        {
            if (CharacterSwitchManager.Instance.currentPlayer.name == "Ball 1")
            {
                moveCarObjectSmall.transform.rigidbody.mass = 0.1f;
            }
        }

        if (other.gameObject.name == "Car_big")
        {
            if (CharacterSwitchManager.Instance.currentPlayer.name == "Ball 2")
            {
                //moveCarObjectBig.transform.rigidbody.mass = 0.1f;
            }
        }
        if (other.gameObject.name == "objectDruckPlatte" && !pressed)
        {
            if(CharacterSwitchManager.Instance.currentPlayer.name != "Ball 1")
            {
                moveBridge.transform.position = moveBridgeOpen.transform.position;
                moveBridge.transform.rotation = moveBridgeOpen.transform.rotation;
                pressed = true;
            }
            Debug.Log(CharacterSwitchManager.Instance.currentPlayer.name + " befindet sich auf der Platte");
        }
    }

    void Update()
    {
        //Spieler 1
        /*if (CharacterSwitchManager.Instance.currentPlayer.name == "Ball 1" && moveObjectCubeBall2.transform.rigidbody.mass < 500f)
        {
            moveObjectCubeBall2.transform.rigidbody.mass = 500f;
        }
        if (CharacterSwitchManager.Instance.currentPlayer.name != "Ball 1" && moveCarObjectSmall.transform.rigidbody.mass < 500f)
        {
            moveCarObjectSmall.transform.rigidbody.mass = 500f;
        }
        // Spieler 2
        if (CharacterSwitchManager.Instance.currentPlayer.name != "Ball 2" && moveCarObjectBig.transform.rigidbody.mass < 500f)
        {
            moveCarObjectBig.transform.rigidbody.mass = 500f;
        }
        // Spieler3
        if (CharacterSwitchManager.Instance.currentPlayer.name != "Ball 3" && moveObjectCubeBall2.transform.rigidbody.mass < 500f)
        {
            moveObjectCubeBall3.transform.rigidbody.mass = 500f;
        }*/

    }
}
