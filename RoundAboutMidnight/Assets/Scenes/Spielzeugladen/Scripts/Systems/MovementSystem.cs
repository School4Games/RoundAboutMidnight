using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour
{
    public static MovementSystem Instance;
    public GameObject mainCamera;
    public bool canControl, instantStop, isJumping;
    public int jumpCount = 0;

    // public Animation jumpAnim;

    private float tempX;

    private Vector3 currentDirection, movement;
	public Vector3 adForce = Vector3.down;

    public bool IsGrounded()
    {
        return Physics.Raycast(CharacterSwitchManager.Instance.currentPlayer.playerTransform.position, -Vector3.up, CharacterSwitchManager.Instance.currentPlayer.PlayerCollider.collider.bounds.extents.y + 0.01f);
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {

        if (StartSystem.Instance.EnableIntroCamera)
            return;

        if(CharacterSwitchManager.Instance.currentPlayer.canControl == false)
        {
            return;
        }

        if(IsGrounded())
        {
            CharacterSwitchManager.Instance.currentPlayer.jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && CharacterSwitchManager.Instance.currentPlayer.jumpCount < CharacterSwitchManager.Instance.currentPlayer.maxJump || Input.GetKey(KeyCode.W) && CharacterSwitchManager.Instance.currentPlayer.jumpCount < CharacterSwitchManager.Instance.currentPlayer.maxJump || Input.GetKey(KeyCode.UpArrow) && CharacterSwitchManager.Instance.currentPlayer.jumpCount < CharacterSwitchManager.Instance.currentPlayer.maxJump)
        {
			CharacterSwitchManager.Instance.currentPlayer.jumpCount+=1;
			CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.AddForce(Vector3.up * CharacterSwitchManager.Instance.currentPlayer.jumpSpeed);
		/*	Vector3 jump = new Vector3(0,Mathf.Sqrt(-2 * 2 * 9.81f),0);
			jump = -adForce.normalized * jump.magnitude;
			CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.AddForce(jump,ForceMode.VelocityChange);
			float 
			*/
           	//jumpAnim.Play();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.AddForce(Vector3.right * CharacterSwitchManager.Instance.currentPlayer.speed * Time.deltaTime);
		}

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.AddForce(Vector3.right * -CharacterSwitchManager.Instance.currentPlayer.speed * Time.deltaTime);
        }
    }
}
