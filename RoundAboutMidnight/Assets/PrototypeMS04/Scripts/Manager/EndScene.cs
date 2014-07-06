﻿using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Untagged"))
        {
            Application.LoadLevel("menu");
        }
    }
}
