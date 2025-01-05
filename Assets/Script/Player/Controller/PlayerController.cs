using UnityEngine;


public enum PlatformSwitch
{
    Android,
    PC
}

public class PlayerController : MonoBehaviour
{
    [Header("Platform Settings")]
    public PlatformSwitch Platforms = PlatformSwitch.PC;

    [Header("ON/OFF")]
    [SerializeField] private bool _canMove = true;
    [SerializeField] private bool _canAnimation = true;
    [SerializeField] private bool _canInteraction = true;

    [Header("Movement Setting")]
    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 2f;
    [SerializeField] private float _crouchSpeed = 2f;
    [SerializeField] private float _gravity = 9.81f;
    [Space]
    [Header("Stamina Parameters")]
    [SerializeField] private float _maxStamina;
    [SerializeField] private float _staminaUseMultiplier;
    [SerializeField] private float _timeBeforeStaminaRegenStarts;
    [SerializeField] private float _staminaValueIncrement;
    [SerializeField] private float _staminaTimeIncrement;
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
    [SerializeField] private float _idleBobSpeed;
    [SerializeField] private float _idleBobAmount;
    [SerializeField] private float _walkBobSpeed;
    [SerializeField] private float _walkBobAmount;
    [SerializeField] private float _runBobSpeed;
    [SerializeField] private float _runBobAmount;
    [SerializeField] private float _crouchBobSpeed;
    [SerializeField] private float _crouchBobAmount;
    [Space]
    [Header("Interaction Setting")]
    [SerializeField] private Vector3 _interactionRayPoint;
    [SerializeField] private float _interactionDistance;
    [SerializeField] private LayerMask _interactionLayer;

    private PlayerInput _inputController;
    private Movement _moveController;
    private FpsCounter _fpsCounter;
    private AnimationController _animationController;
    private InteractionManager _interactionManager;
    private InventoryManager _inventoryManager;
    private StaminaSystem _staminaManager;

    private void Awake()
    {
        _inputController = GetComponent<PlayerInput>();
        _moveController = GetComponent<Movement>();
        _staminaManager = GetComponent<StaminaSystem>();
        _animationController = GetComponent<AnimationController>();
        _interactionManager = GetComponent<InteractionManager>();
        _fpsCounter = GameObject.FindGameObjectWithTag("FPS").GetComponent<FpsCounter>();
        _inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (_canMove)
        {
            AddControllers();
        }

        if (_canAnimation)
        {
            _animationController.ActiveAnimation(_inputController.isFlashlite, _inventoryManager.Revolver, _inventoryManager.Knife);
        }

        _fpsCounter.FPS();
    }

    private void AddControllers()
    {
        MoveController();
        CameraController();
        InputController();
        CrouchController();
        InteractionController();
        StaminaController();

    }

    private void MoveController()
    {
        if (Platforms == PlatformSwitch.PC)
        {
            _moveController.Move(_inputController.PC(_walkSpeed, _runSpeed, _crouchSpeed), _gravity);
        }

        _moveController.HandlHeadBobbing(_inputController.MoveDirection, _inputController.isRunning,
        _crouchBobSpeed, _runBobSpeed, _walkBobSpeed, _idleBobSpeed,
        _crouchBobAmount, _runBobAmount, _walkBobAmount, _idleBobAmount);
    }

    private void CrouchController()
    {
        if (Platforms == PlatformSwitch.PC)
        {
            if (_inputController.isCrouch && !_moveController.DurringCrouchAnimation && !_moveController.isCrouching)
                StartCoroutine(_moveController.CrouchStand(_standingHeight, _crouchingHeight, _timeToCrouch, _standingCenter, _crouchingCenter));
            else if (!_inputController.isCrouch && !_moveController.DurringCrouchAnimation && _moveController.isCrouching)
                StartCoroutine(_moveController.CrouchStand(_standingHeight, _crouchingHeight, _timeToCrouch, _standingCenter, _crouchingCenter));
        }
    }

    private void CameraController()
    {
        _moveController.CameraInput(_lookXSpeed, _lookYSpeed, _lookXLimit);
    }

    private void InputController()
    {
        if (Platforms == PlatformSwitch.PC)
        {
            _inputController.CrouchAndStand(_moveController);
            _inputController.RuningStaminaCheck(_staminaManager.Stamina());

            if (_inventoryManager.Flashlite == true) { _inputController.FlashLite(); }
        }
    }

    private void InteractionController()
    {
        if (_canInteraction)
        {
            _interactionManager.HandleInteractionCheck(_interactionRayPoint, _interactionDistance);
            _interactionManager.HandleInteractionInput(_inputController.InteractionKey(), _interactionRayPoint, _interactionDistance, _interactionLayer);
        }
    }

    private void StaminaController()
    {
        _staminaManager.StaminaSubtraction(_inputController.isRunning, _inputController.isCrouch, 
                                           _moveController.PlayerCharacterController.isGrounded,
                                           _staminaUseMultiplier, _timeBeforeStaminaRegenStarts, _staminaTimeIncrement, _staminaValueIncrement, _maxStamina);
    }
}
