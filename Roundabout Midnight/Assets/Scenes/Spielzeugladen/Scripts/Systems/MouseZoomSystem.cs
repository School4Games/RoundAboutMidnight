using UnityEngine;
using System.Collections;

public class MouseZoomSystem : MonoBehaviour
{
    public float minZoom = 15f;
    public float maxZoom = 90f;
    public float sensitivity = 15f;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        float zoom = mainCamera.fieldOfView;
        zoom -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        mainCamera.fieldOfView = zoom;
    }

}