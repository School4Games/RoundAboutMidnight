using UnityEngine;
using System.Collections;

public class CameraFlyingEmotion : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            EmotionSystem.instance.feeling = 1;
            EmotionSystem.instance._showEmotion = true;
        }
    }
}
