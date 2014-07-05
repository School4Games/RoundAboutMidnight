using UnityEngine;
using System.Collections;

public class CameraSystem : MonoBehaviour {

    public static CameraSystem Instance;

    public Transform cTarget;

    void Awake()
    {
        Instance = this;
    }
    void Update(){
        
    }

    void FixedUpdate(){
        float newPos = Mathf.Lerp(this.transform.position.x, cTarget.transform.position.x, 1.0f * Time.deltaTime);
        float newPosY = Mathf.Lerp(this.transform.position.y, cTarget.transform.position.y + 0.2f, 1.0f * Time.deltaTime);
        this.transform.position = new Vector3(newPos, newPosY, this.transform.position.z);
    }
}
