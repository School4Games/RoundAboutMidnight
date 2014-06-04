using UnityEngine;
using System.Collections;

public class TrampolinManager : MonoBehaviour {

    public static TrampolinManager Instance;

    public bool activetrampoline = false;

    void Awake()
    {
        Instance = this;
    }

	void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Car_small")
        {
            activetrampoline = true;
        }
    }
}
