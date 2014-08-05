using UnityEngine;
using System.Collections;

public class EmotionManager : MonoBehaviour {

    public static EmotionManager Instance;

    public bool _displayEmotion = false;
	public bool _Emo2 = true ; 
    public GameObject _emotions;
    public GameObject _emotion2;
    public GameObject Player1;


    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        _emotions.transform.position = new Vector3(Player1.transform.position.x, Player1.transform.position.y + 0.2f, Player1.transform.position.z); 
        if(_displayEmotion)
        {
            _emotions.SetActive(true);
        }
        else
        {
            _emotions.SetActive(false);
        }

		if(_Emo2){
			_emotion2.SetActive(true);

		}else{
			_emotion2.SetActive(false);
		}

    }
    
 
}
