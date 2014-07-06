using UnityEngine;
using System.Collections;

public class IntroEndpoint : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IntroCam"))
        {
            CamerIntro.Instance.introCamera.enabled = false;
            CamerIntro.Instance.mainCamera.enabled = true;
            CamerIntro.Instance.displayIntroText = false;
            Destroy(this.gameObject);
            Debug.Log("Camera switch ( intro ende )");
        }
    }
}
