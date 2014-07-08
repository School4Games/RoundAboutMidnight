using UnityEngine;
using System.Collections;

public class CamerIntro : MonoBehaviour {

    public static CamerIntro Instance;

    public bool EnableIntroCamera = true;

    public Camera introCamera;
    public Camera mainCamera;

    public GUIStyle introFontStyle;
	public GUIStyle introFontStyle2;

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

        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 150, 150, 50), "Befreie den Baseball ! ", introFontStyle);
		GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 75, 150, 50 ),"(Press 2 to Skip)",introFontStyle2);
    }
}
