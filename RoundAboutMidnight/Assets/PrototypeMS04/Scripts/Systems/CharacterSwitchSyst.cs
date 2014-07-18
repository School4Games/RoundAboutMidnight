using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CharacterSwitchSyst : MonoBehaviour
{
    // Wir benutzen singleton
    public static CharacterSwitchSyst Instance;

    public int currentBall;
    public Transform[] balls;

    void Start()
    {
        Instance = this;

        // Beim starten wird Ball 0 automatisch als currentBall verwendet
        switchBall(0);
    }

    public void Update() {
        // Wenn die Taste 1 gedrückt wird dann
        if (Input.GetKeyDown(KeyCode.Q)){
            // wird Ball 0 ausgewählt
            switchBall(0); 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            // wird Ball 0 ausgewählt
            switchBall(1);
        }
    }

    public void switchBall(int num)
    {
        currentBall = num;
        // solange i kleiner ist als der inhalt von balls wird i ++ gerechnet
        for (int i = 0; i < balls.Length; i++)
        {
            // wenn i gleich der zugewiesene parameter ist dann
            if (i == num)
            {
                // balls[i].gameObject.SetActive(true);
                // Dann ist das neue Camera target der balls[i] 
                balls[i].GetComponent<Movement>().enabled = true;
                CameraSystem.Instance.cTarget = balls[i].transform;
            }
            else
            {
                // Wenn das nicht der Fall ist dann wird das Movementscript deaktiviert
             balls[i].GetComponent<Movement>().enabled = false;
            }
        }
    }
}