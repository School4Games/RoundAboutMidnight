using UnityEngine;
using System.Collections;

public class MoveBridge : MonoBehaviour {

    public bool isRotate = false;

    public GameObject moveBridgeObject;

	void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Car_big" && !isRotate)
        {
            if (CharacterSwitchManager.Instance.currentPlayer.name == "Ball 2")
            {
                isRotate = true;
                moveBridgeObject.transform.rigidbody.mass = 2f;
                Debug.Log("1");
            }
        }
    }

    void Update()
    {
        if (CharacterSwitchManager.Instance.currentPlayer.name != "Ball 2" && moveBridgeObject.transform.rigidbody.mass < 500f || isRotate)
        {
            StartCoroutine(WaitforFall());
        }
    }
    IEnumerator WaitforFall()
    {
        yield return new WaitForSeconds(0.5f);
        moveBridgeObject.transform.rigidbody.mass = 500f;
    }
}
