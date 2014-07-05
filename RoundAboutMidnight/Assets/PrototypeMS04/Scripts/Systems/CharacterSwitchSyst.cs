using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CharacterSwitchSyst : MonoBehaviour
{
    public static CharacterSwitchSyst Instance;

    public int currentBall;
    public Transform[] balls;

    void Start()
    {
        Instance = this;

        switchBall(0);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            switchBall(0);
        }
    }

    public void switchBall(int num)
    {
        currentBall = num;
        for (int i = 0; i < balls.Length; i++)
        {
            if (i == num)
            {
                // balls[i].gameObject.SetActive(true);
                CameraSystem.Instance.cTarget = balls[i].transform;
            }
            else
                balls[i].gameObject.SetActive(false);
        }
    }
}