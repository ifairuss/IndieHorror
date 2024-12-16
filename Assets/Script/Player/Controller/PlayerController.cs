using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("ON/OFF")]
    [SerializeField] private bool _canMove = true;

    [Header("Movement Setting")]
    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 2f;
    [SerializeField] private float _crouchSpeed = 2f;
    [SerializeField] private float _gravity = 9.81f;
    [Space]
    [Header("Look Setting")]
    [SerializeField] private float _lookXSpeed = 1f;
    [SerializeField] private float _lookYSpeed = 1f;
    [SerializeField] private int _lookXLimit = 90;
    [Space]
    [Header("Crouch Setting")]
    [SerializeField] private float _standingHeight;
    [SerializeField] private float _crouchingHeight;
    [SerializeField] private float _timeToCrouch;
    [SerializeField] private Vector3 _standingCenter;
    [SerializeField] private Vector3 _crouchingCenter;
    [Space]
    [Header("Head-Bobbing Setting")]
    [SerializeField] private float _walkBobSpeed;
    [SerializeField] private float _walkBobAmount;
    [SerializeField] private float _runBobSpeed;
    [SerializeField] private float _runBobAmount;
    [SerializeField] private float _crouchBobSpeed;
    [SerializeField] private float _crouchBobAmount;

    private PlayerInput _inputController;
    private Movement _moveController;

    private void Awake()
    {
        _inputController = GetComponent<PlayerInput>();
        _moveController = GetComponent<Movement>();
    }

    private void Update()
    {
        AddControllers();
        Crouch();
    }

    private void Crouch()
    {
        if (_inputController.isCrouch && !_moveController.DurringCrouchAnimation && !_moveController.isCrouching)
            StartCoroutine(_moveController.CrouchStand(_standingHeight, _crouchingHeight, _timeToCrouch, _standingCenter, _crouchingCenter));
        else if (!_inputController.isCrouch && !_moveController.DurringCrouchAnimation && _moveController.isCrouching)
            StartCoroutine(_moveController.CrouchStand(_standingHeight, _crouchingHeight, _timeToCrouch, _standingCenter, _crouchingCenter));
    }

    private void AddControllers()
    {
        _inputController.CrouchAndStand(_moveController);

        _moveController.Move(_inputController.PC(_walkSpeed, _runSpeed, _crouchSpeed), _gravity, _canMove);

        _moveController.CameraInput(_lookXSpeed, _lookYSpeed, _lookXLimit);

        _moveController.HandlHeadBobbing(_inputController.MoveDirection, _inputController.isRunning,
        _crouchBobSpeed, _runBobSpeed, _walkBobSpeed,
        _crouchBobAmount, _runBobAmount, _walkBobAmount);
    }
}
