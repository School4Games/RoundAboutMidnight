using UnityEngine;
using System.Collections;

public class Ball1Collisions : MonoBehaviour {

	public static Ball1Collisions Instance;
	
    public Transform car;
	public GameObject Carar;
    public Transform endcarpoint;
    public bool movecar = false;
	public int Selfdes;
	public bool CanControl = true;
	public GameObject Playerpoint;
	public int Count ;

	void Awake()
	{
		Instance = this;
	}

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("control")&& Count == 0 ){
            movecar = true;
			CanControl = false;
			this.rigidbody.velocity = new Vector3(0,0,0);
			this.transform.position = Playerpoint.transform.position;
			this.rigidbody.velocity = new Vector3(0,0,0);
			Debug.Log ("Take a break");
			this.rigidbody.isKinematic = true;
            EmotionManager.Instance._displayEmotion = true;
			EmotionManager.Instance._Emo2 = false;
			Count = 1;
			StartCoroutine(Example());
		
        }
    }

	
	IEnumerator Example(){
		yield return new WaitForSeconds(3.5f);
		CharakterManger.Instance.Waitforanimation= true;
		Backto();
	}

	void Backto(){
		EmotionManager.Instance._displayEmotion = false;
		CharakterManger.Instance.Controllof2 = true;
		CanControl = true;
		this.rigidbody.isKinematic = false;
		Debug.Log("Controlle ist da");
	}


    void FixedUpdate()
    {
		if(car){

		
        if(movecar){
            car.transform.position = Vector3.Lerp(car.transform.position, endcarpoint.transform.position, Time.deltaTime * 0.7f);
            // movecarobject.rigidbody.mass = 0.01f;
			Destroy(Carar,4f);
			//Destroy(this,3f);
			}
        }
    }
}
