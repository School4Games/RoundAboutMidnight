using UnityEngine;
using System.Collections;

public class PressLightTrigger : MonoBehaviour {

    public GameObject[] lightObject;

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("BallJumpTrigger"))
        {
            if (EnableBalls.Instance.enableBall3)
            {
                return;
            }

            for(int i = 0; i < lightObject.Length; i++)
            {
                lightObject[i].SetActive(true);
            }
            
            EmotionSystem.instance.feeling = 2;
            EmotionSystem.instance._showEmotion = true;
            EnableBalls.Instance.enableBall3 = true;
            CharacterSwitchManager.Instance.ChangeCurrentPlayer(Player.GetPlayerByName("Ball 3"));
            CharacterSwitchManager.Instance.currentPlayer.canControl = true;
			Debug.Log("Du hast mich geweckt");
        }
    }
}
