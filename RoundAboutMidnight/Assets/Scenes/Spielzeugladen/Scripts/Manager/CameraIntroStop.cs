using UnityEngine;
using System.Collections;

public class CameraIntroStop : MonoBehaviour {

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            StartCoroutine(WaitCameraStop());
        }
    }

    IEnumerator WaitCameraStop()
    {
        iTween.Pause();
        yield return new WaitForSeconds(2);
        iTween.Resume();
    }

}
