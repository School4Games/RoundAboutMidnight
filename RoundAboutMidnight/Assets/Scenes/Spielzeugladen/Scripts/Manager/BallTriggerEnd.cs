using UnityEngine;
using System.Collections;

public class BallTriggerEnd : MonoBehaviour {

    public GUIStyle txtEndeStyle;
    public bool _displayEnde = false;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("BallJumpTrigger"))
        {
            Time.timeScale = 0;
            _displayEnde = true;
        }
    }

    void OnGUI()
    {
        if (_displayEnde)
        {
            GUI.Label(new Rect(Screen.width / 2 - 15, Screen.height / 2 - 25, 30, 50), "Ende",txtEndeStyle);
        }
    }
}
