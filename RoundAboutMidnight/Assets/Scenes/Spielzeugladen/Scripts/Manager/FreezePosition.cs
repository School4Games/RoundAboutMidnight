using UnityEngine;
using System.Collections;

public class FreezePosition : MonoBehaviour {

    void Update()
    {
        Vector3 position = EnableBalls.Instance._ball3.transform.position;
        position.y = transform.position.y;
        transform.position = new Vector3(position.x + 0.7f,position.y,position.z);
    }
}
