using UnityEngine;
using System.Collections;
using System;

public class EmotionSystem : MonoBehaviour {

    public static EmotionSystem Instance;

    public GUIStyle emotionStyle;
    public Emotion feeling;
    public bool showEmotion = false;

    private int jumps;

    public void ShowEmotion(Emotion newemotion)
    {
        if (showEmotion)
            return;

        feeling = newemotion;
        StartCoroutine(WaitForEmotionSystem());
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumps++;
        }
        if(jumps == 3)
        {
            ShowEmotion(Emotion.Muede);
        }
    }

    IEnumerator WaitForEmotionSystem()
    {
        showEmotion = true;
        yield return new WaitForSeconds(3);
        showEmotion = false;
        jumps = 0;
    }


}

[Serializable]
public enum Emotion
{
    Hungrig,
    Muede
    /*
     * ...
     * */
}