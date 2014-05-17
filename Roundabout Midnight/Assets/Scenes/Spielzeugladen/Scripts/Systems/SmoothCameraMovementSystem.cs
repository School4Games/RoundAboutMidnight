using UnityEngine;
using System.Collections;

public class SmoothCameraMovementSystem : MonoBehaviour
{
    public Transform target, camera;

    public float smoothTime = 0.5F;

    private float yVelocity = 0.0F;

    void Update()
    {
        float newPos = Mathf.Lerp(camera.position.x, target.position.x, 5.0f * Time.deltaTime);
        float newPosY = Mathf.Lerp(camera.position.y, target.position.y + 6.7f, 5.0f * Time.deltaTime);
        transform.position = new Vector3(newPos, newPosY, transform.position.z);
    }
}