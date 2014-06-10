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

    public bool moveBrideGoOpen = false;
    public bool moveBrideGoClose = false;
    public float brideMoveSpeed = 0.2f;

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
                moveBrideGoOpen = false;
                moveBrideGoClose = true;
                pressed = false;
            }
            Debug.Log("Test2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trampolin_Cam")
        {
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Trampolin_Cam")
        {
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Trampolin")
        {

            CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity = new Vector3(CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity.x, 9);
            SmoothCameraMovementSystem.instance.activeCam = false;
            StartCoroutine(WaitForActiveCam());
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
                moveBrideGoClose = false;
                moveBrideGoOpen = true;
                            
                pressed = true;
            }
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
        // Spieler3*/
        if (CharacterSwitchManager.Instance.currentPlayer.name != "Ball 3" && moveObjectCubeBall3.transform.rigidbody.mass < 500f)
        {
            moveObjectCubeBall3.transform.rigidbody.mass = 500f;
        }

        if(moveBrideGoOpen)
        {
            moveBridge.transform.rotation = Quaternion.Lerp(moveBridge.transform.rotation, moveBridgeOpen.transform.rotation, Time.deltaTime * brideMoveSpeed);
            moveBridge.transform.position = Vector3.Lerp(moveBridge.transform.position, moveBridgeOpen.transform.position, Time.deltaTime * brideMoveSpeed); 
        }
        if(moveBrideGoClose)
        {
            moveBridge.transform.rotation = Quaternion.Lerp(moveBridge.transform.rotation, moveBrdigeClosed.transform.rotation, Time.deltaTime * brideMoveSpeed);
            moveBridge.transform.position = Vector3.Lerp(moveBridge.transform.position, moveBrdigeClosed.transform.position, Time.deltaTime * brideMoveSpeed); 
        }
        

    }
    IEnumerator WaitForActiveCam()
    {
        SmoothCameraMovementSystem.instance.activeCam = false;
        yield return new WaitForSeconds(0.1f);
        SmoothCameraMovementSystem.instance.activeCam = true;
    }
    
}
