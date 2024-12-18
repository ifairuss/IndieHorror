using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Controll Setting")]
    [SerializeField] private KeyCode _runInput = KeyCode.LeftShift;
    [SerializeField] private KeyCode _crouchInput = KeyCode.C;

    public Vector3 MoveDirection = Vector3.zero;

    public bool isRunning => Input.GetKey(_runInput) && isCrouch != true;
    public bool isCrouch;

    public Vector3 PC(float walkSpeed, float runSpeed, float crouchSpeed)
    {
        float directionY = (isCrouch ? crouchSpeed : isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
        float directionX = (isCrouch ? crouchSpeed : isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");

        float moveDirectionY = MoveDirection.y;

        MoveDirection = (transform.TransformDirection(Vector3.forward) * directionX
                        + transform.TransformDirection(Vector3.right) * directionY);

        MoveDirection.y = moveDirectionY;

        return MoveDirection;
    }

    public void CrouchAndStand(Movement _movement)
    {
        if (Input.GetKey(_crouchInput) && !_movement.DurringCrouchAnimation && _movement.PlayerCharacterController.isGrounded && isCrouch == false)
            isCrouch = true;
        else if (Input.GetKey(_crouchInput) && !_movement.DurringCrouchAnimation && _movement.PlayerCharacterController.isGrounded && isCrouch == true)
            isCrouch = false;
    }

    // private Vector3 Phone(float speed)
    // {
    //    return;
    // }
}
