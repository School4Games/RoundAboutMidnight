using UnityEngine;
using System.Collections;
using System;

public class EmotionSystem : MonoBehaviour {

    public static EmotionSystem instance;

    public bool _showEmotion, _currentlyShowEmotion;
    public Texture2D[] emotionTexture;


    public int feeling;
    /*
     * 1 = scary
     * 2 = happy
     * */

    void Awake()
    {
        feeling = 0;
        instance = this;
    }

    void Update()
    {
        if (feeling == 1 && _showEmotion && !_currentlyShowEmotion)
        {
            StartCoroutine(WaitForShowEmotion());
            //EnableBalls.Instance.emotionBall3.renderer.material.mainTexture = emotionTexture[1];
        }

        if (feeling == 2 && _showEmotion && !_currentlyShowEmotion)
        {
            StartCoroutine(WaitForShowEmotion());
            //EnableBalls.Instance.emotionBall3.renderer.material.mainTexture = emotionTexture[2];
        }
    }

    IEnumerator WaitForShowEmotion()
    {
        EnableBalls.Instance.emotionBall3.SetActive(true);
        _currentlyShowEmotion = true;
        yield return new WaitForSeconds(3.9f);
        _showEmotion = false;
        _currentlyShowEmotion = false;
        EnableBalls.Instance.emotionBall3.SetActive(false);
    }

}
