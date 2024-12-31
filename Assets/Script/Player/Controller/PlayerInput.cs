using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Controll Setting")]
    [SerializeField] private KeyCode _runInput = KeyCode.LeftShift;
    [SerializeField] private KeyCode _crouchInput = KeyCode.C;
    [SerializeField] private KeyCode _flashLite = KeyCode.F;
    [SerializeField] private KeyCode _interaction = KeyCode.E;

    public Vector3 MoveDirection = Vector3.zero;

    public bool isRunning => Input.GetKey(_runInput) && isCrouch != true;
    public bool isCrouch;
    public bool isFlashlite;

    private float _timerInput = 0.5f;

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

    public void FlashLite()
    {
        if(_timerInput <= 0)
        {
            if (Input.GetKey(_flashLite) && isFlashlite == false)
            {
                isFlashlite = true;
                _timerInput = 0.5f;
            }
            else if (Input.GetKey(_flashLite) && isFlashlite == true)
            {
                isFlashlite = false;
                _timerInput = 0.5f;
            }
        }
        else
        {
            _timerInput -= Time.deltaTime;
        }
    }

    public KeyCode InteractionKey() => _interaction;

    // private Vector3 Phone(float speed)
    // {
    //    return;
    // }
}
