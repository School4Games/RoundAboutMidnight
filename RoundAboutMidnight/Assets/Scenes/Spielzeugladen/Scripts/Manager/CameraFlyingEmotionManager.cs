using UnityEngine;
using System.Collections;

public class CameraFlyingEmotionManager : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            EmotionSystem.instance.feeling = 1;
            EmotionSystem.instance._showEmotion = true;
        }
    }
}
