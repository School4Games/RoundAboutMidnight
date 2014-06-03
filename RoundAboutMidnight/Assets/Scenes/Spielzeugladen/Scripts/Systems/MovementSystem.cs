using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour
{
    public static MovementSystem Instance;

    public GameObject mainCamera;
    public bool canControl, instantStop, isJumping;
    public int jumpCount = 0;

    private float tempX;

    private Vector3 currentDirection, movement;

    public bool IsGrounded()
    {
        return Physics.Raycast(CharacterSwitchManager.Instance.currentPlayer.playerTransform.position, -Vector3.up, CharacterSwitchManager.Instance.currentPlayer.PlayerCollider.collider.bounds.extents.y + 0.1f);
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {

        if (StartSystem.Instance.EnableIntroCamera)
            return;

        if(IsGrounded())
        {
            CharacterSwitchManager.Instance.currentPlayer.jumpCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && CharacterSwitchManager.Instance.currentPlayer.jumpCount < CharacterSwitchManager.Instance.currentPlayer.maxJump || Input.GetKey(KeyCode.W) && CharacterSwitchManager.Instance.currentPlayer.jumpCount < CharacterSwitchManager.Instance.currentPlayer.maxJump || Input.GetKey(KeyCode.UpArrow) && CharacterSwitchManager.Instance.currentPlayer.jumpCount < CharacterSwitchManager.Instance.currentPlayer.maxJump)
        {
            CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity = new Vector3(CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity.x, CharacterSwitchManager.Instance.currentPlayer.jumpSpeed);
            CharacterSwitchManager.Instance.currentPlayer.jumpCount += 1;
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
