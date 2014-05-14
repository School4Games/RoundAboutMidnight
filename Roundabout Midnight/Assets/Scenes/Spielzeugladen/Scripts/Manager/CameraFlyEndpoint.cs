using UnityEngine;
using System.Collections;

public class CameraFlyEndpoint: MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            StartCoroutine(WaitForCameraChange());
        }
    }

    IEnumerator WaitForCameraChange()
    {
        
        yield return new WaitForSeconds(2);
        StartSystem.Instance.mainCamera2.enabled = false;
        StartSystem.Instance.mainCamera1.enabled = true;
        StartSystem.Instance.EnableIntroCamera = false;
    }
}
