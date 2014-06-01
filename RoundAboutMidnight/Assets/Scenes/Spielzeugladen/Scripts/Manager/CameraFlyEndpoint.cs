using UnityEngine;
using System.Collections;

public class CameraFlyEndpoint: MonoBehaviour
{

    #region Texte
    public string _skipText = "Überspringen (Leertaste)";
    #endregion Texte

    public static CameraFlyEndpoint Instance;

    public GameObject _cameraFlyingObject;

    public GUIStyle txtSkipStyle;
    public bool _SkipIntro;
    
    void Awake()
    {
        Instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            StartCoroutine(WaitForCameraChange());
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _SkipIntro = true;
            StartSystem.Instance.mainCamera2.enabled = false;
            StartSystem.Instance.mainCamera1.enabled = true;
            StartSystem.Instance.EnableIntroCamera = false;
            _cameraFlyingObject.SetActive(false);
        }
    }

    void OnGUI()
    {
        if(!_SkipIntro)
        {
            GUI.Label(new Rect(Screen.width / 2 - 15, Screen.height - 50, 30, 50), _skipText, txtSkipStyle);
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
