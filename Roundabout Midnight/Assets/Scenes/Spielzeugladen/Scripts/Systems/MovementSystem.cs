using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour
{
    public static MovementSystem Instance;

    public GameObject mainCamera;
    public bool canControl, instantStop, isJumping;
    public float gravity = 9.81f;

    private Vector3 currentDirection;

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
        if (!canControl)
            return;
        #region Input/Direction
        #region Left/Right
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            currentDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            currentDirection = transform.TransformDirection(currentDirection);
        }
        else
        {
             if (instantStop)
                CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity = new Vector3(0, CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity.y, 0);

                currentDirection = Vector3.zero;
        }
        #endregion

        #region Jump
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            currentDirection.y = CharacterSwitchManager.Instance.currentPlayer.jumpSpeed;


        #endregion
        #endregion

        if (!IsGrounded())
            return;

        if (currentDirection == Vector3.zero)
            return;

        currentDirection.y -= gravity * Time.deltaTime;

        Vector3 right = new Vector3(currentDirection.z, 0, -currentDirection.x);
        CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.velocity = currentDirection * CharacterSwitchManager.Instance.currentPlayer.speed;

        CharacterSwitchManager.Instance.currentPlayer.playerRigidbody.AddTorque(right);
    }


}
