using UnityEngine;
using System.Collections;

public class BallTriggerEnd : MonoBehaviour {

    public GUIStyle txtEndeStyle;
    public bool _displayEnde = false;

    public GameObject ball1, ball2, goal1,goal2;
    public bool _setPosition = false;
  
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("BallJumpTrigger"))
        {
            _displayEnde = true;
        }
    }

    void Update()
    {
        if(_displayEnde)
        {
            CharacterSwitchManager.Instance.currentPlayer.canControl = false;

            if(!_setPosition)
            {
                ball1.transform.position = goal1.transform.position;
                ball2.transform.position = goal2.transform.position;
                _setPosition = true;
            }
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
