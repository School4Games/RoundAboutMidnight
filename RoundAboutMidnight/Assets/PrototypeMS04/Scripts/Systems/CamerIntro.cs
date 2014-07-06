using UnityEngine;
using System.Collections;

public class CamerIntro : MonoBehaviour {

    public static CamerIntro Instance;

    public bool EnableIntroCamera = true;

    public Camera introCamera;
    public Camera mainCamera;

    public GUIStyle introFontStyle;

    public bool displayIntroText = true;

    void Awake()
    {
        Instance = this;
    }

	void Start()
    {
        mainCamera.enabled = false;
        introCamera.enabled = true;
    }

    void OnGUI()
    {
        if (!displayIntroText)
            return;

        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 75, 150, 50), "Gleich gehts los ... ", introFontStyle);
    }
}
