using UnityEngine;
using System.Collections;

public class EmotionGUI : MonoBehaviour
{
    public Texture2D emotionSpeechBubbleTexture;
    public Rect emotionRect;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector2 curPlayerScreenPos = new Vector2(mainCamera.WorldToScreenPoint(CharacterSwitchManager.Instance.currentPlayer.playerTransform.position).x, mainCamera.WorldToScreenPoint(CharacterSwitchManager.Instance.currentPlayer.playerTransform.position.y));
        emotionRect = new Rect(CharacterSwitchManager.Instance.currentPlayer.playerTransform.position.x + 600, CharacterSwitchManager.Instance.currentPlayer.playerTransform.position.x, 250, 200);
    }

    void OnGUI()
    {
        if (EmotionSystem.Instance.showEmotion)
        {
            GUI.DrawTexture(emotionRect, emotionSpeechBubbleTexture);
            GUI.Label(new Rect(emotionRect.x + 100, emotionRect.y + 80, 200, 45), EmotionSystem.Instance.feeling.ToString(), EmotionSystem.Instance.emotionStyle);
        }
    }

}
