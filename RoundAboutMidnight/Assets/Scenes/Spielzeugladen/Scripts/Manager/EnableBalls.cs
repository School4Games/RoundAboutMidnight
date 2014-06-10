using UnityEngine;
using System.Collections;

public class EnableBalls : MonoBehaviour {

    public static EnableBalls Instance;

    public bool enableBall1, enableBall2, enableBall3;
    public Transform _ball3, _ball2, _ball1;
    public GameObject emotionBall3;
    public GameObject emotionBall3_shock;

 
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        
    }


}
