using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Controll Setting")]
    [SerializeField] private KeyCode _runInput = KeyCode.LeftShift;
    [SerializeField] private KeyCode _crouchInput = KeyCode.C;

    private Vector3 _moveDirection = Vector3.zero;

    private Movement _movement;

    public bool isRunning => Input.GetKey(_runInput);
    public bool isCrouch;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_crouchInput) && !_movement.DurringCrouchAnimation && _movement.PlayerCharacterController.isGrounded && isCrouch == false)
            isCrouch = true;
        else if (Input.GetKeyDown(_crouchInput) && !_movement.DurringCrouchAnimation && _movement.PlayerCharacterController.isGrounded && isCrouch == true)
            isCrouch = false;
    }

    public Vector3 PC(float walkSpeed, float runSpeed, float crouchSpeed)
    {
        float directionY = (isCrouch ? crouchSpeed : isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
        float directionX = (isCrouch ? crouchSpeed : isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");

        float moveDirectionY = _moveDirection.y;

        _moveDirection = (transform.TransformDirection(Vector3.forward) * directionX
                        + transform.TransformDirection(Vector3.right) * directionY);

        _moveDirection.y = moveDirectionY;

        return _moveDirection;
    }

    // private Vector3 Phone(float speed)
    // {
    //    return;
    // }
}
