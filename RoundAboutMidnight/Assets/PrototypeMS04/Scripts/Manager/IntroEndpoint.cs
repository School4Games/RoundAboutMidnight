using UnityEngine;
using System.Collections;

public class IntroEndpoint : MonoBehaviour {
	

	void Update(){
		if(Input.GetKeyDown ("2")){
			CamerIntro.Instance.introCamera.enabled = false;
			CamerIntro.Instance.mainCamera.enabled = true;
			CamerIntro.Instance.displayIntroText = false;
			Destroy(this.gameObject);
			Debug.Log("Camera switch ( intro ende )");
		}
	}

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
