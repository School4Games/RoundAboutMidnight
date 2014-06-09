using UnityEngine;
using System.Collections;

public class SmoothCameraMovementSystem : MonoBehaviour
{
    public static SmoothCameraMovementSystem instance;

    public bool activeCam;
    public Transform target, camera;

    public float smoothTime = 0.5F;

    private float yVelocity = 0.0F;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(activeCam)
        {
            float newPos = Mathf.Lerp(camera.position.x, target.position.x, 5.0f * Time.deltaTime);
            float newPosY = Mathf.Lerp(camera.position.y, target.position.y + 6.7f, 5.0f * Time.deltaTime);
            transform.position = new Vector3(newPos, newPosY, transform.position.z);
        }

    }
}