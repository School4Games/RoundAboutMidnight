using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour
{
    public static MovementSystem Instance;

    public GameObject mainCamera;
    public bool canControl, instantStop, isJumping;

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
        if (Input.GetKey(KeyCode.Space) && IsGrounded() || Input.GetKey(KeyCode.W) && IsGrounded() || Input.GetKey(KeyCode.UpArrow) && IsGrounded())
        {
            CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity = new Vector3(CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity.x, CharacterSwitchManager.Instance.currentPlayer.jumpSpeed);
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
