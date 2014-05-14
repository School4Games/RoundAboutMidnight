using UnityEngine;
using System.Collections;

public class StartSystem : MonoBehaviour {

    public static StartSystem Instance;

    public bool EnableIntroCamera = true;

    public Camera mainCamera1;
    public Camera mainCamera2;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        mainCamera1.enabled = false;
        mainCamera2.enabled = true;
    }

    void Update()
    {
        if(mainCamera1.enabled && mainCamera1.fieldOfView != 10f)
        {
            mainCamera1.fieldOfView = 10f;
        }
    }
}
