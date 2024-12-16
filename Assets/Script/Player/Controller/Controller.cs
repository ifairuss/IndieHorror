using UnityEngine;

public class Controller : MonoBehaviour
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


    private PlayerInput _inputController;
    private Movement _moveController;
    private HeadBobbing _headBobbing;

    private void Awake()
    {
        _inputController = GetComponent<PlayerInput>();
        _moveController = GetComponent<Movement>();
        _headBobbing = GetComponentInChildren<HeadBobbing>();
    }

    private void Update()
    {
        _moveController.Move(_inputController.PC(_walkSpeed,_runSpeed,_crouchSpeed), _gravity, _canMove);

        _moveController.CameraInput(_lookXSpeed, _lookYSpeed, _lookXLimit);

        if (_inputController.isCrouch && !_moveController.DurringCrouchAnimation && !_moveController.isCrouching)
            StartCoroutine(_moveController.CrouchStand(_standingHeight, _crouchingHeight, _timeToCrouch, _standingCenter, _crouchingCenter));
        else if (!_inputController.isCrouch && !_moveController.DurringCrouchAnimation && _moveController.isCrouching)
            StartCoroutine(_moveController.CrouchStand(_standingHeight, _crouchingHeight, _timeToCrouch, _standingCenter, _crouchingCenter));
    }
}
