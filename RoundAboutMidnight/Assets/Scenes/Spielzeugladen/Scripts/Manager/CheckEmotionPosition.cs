using UnityEngine;
using System.Collections;

public class CheckEmotionPosition : MonoBehaviour {

    public GameObject emotionObject;

    public float x;
    public float y;

    void FixedUpdate()
    {
        this.transform.position = new Vector3(emotionObject.transform.position.x + x, emotionObject.transform.position.y + y, emotionObject.transform.position.z);
    }
}
