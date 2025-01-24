using UnityEngine;

public enum PlatformSwitch
{
    Android,
    PC
}

public class PlayerController : MonoBehaviour
{
    [Header("Platform Settings")]
    public PlatformSwitch Platforms;

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
    [SerializeField] private float _interactionDistance;
    [SerializeField] private LayerMask _interactionLayer;

    private PlayerInput _inputController;
    private Movement _moveController;
    private FpsCounter _fpsCounter;
    private AnimationController _animationController;
    private InteractionManager _interactionManager;
    private InventoryManager _inventoryManager;
    private StaminaSystem _staminaManager;
    private FixedTouchField _fixedTouchField;

    private void Awake()
    {
        _inputController = GetComponent<PlayerInput>();
        _moveController = GetComponent<Movement>();
        _staminaManager = GetComponent<StaminaSystem>();
        _animationController = GetComponent<AnimationController>();
        _interactionManager = GetComponent<InteractionManager>();
        _fpsCounter = GameObject.FindGameObjectWithTag("FPS").GetComponent<FpsCounter>();
        _inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        _fixedTouchField = GameObject.FindGameObjectWithTag("Android").GetComponentInChildren<FixedTouchField>();

        if (Platforms == PlatformSwitch.PC)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        if (_canMove)
        {
            AddControllers();
        }

        if (_canAnimation)
        {
            _animationController.ActiveAnimation(_inputController.isFlashlite, _inventoryManager.Revolver, _inventoryManager.Knife, _inventoryManager.Crowbar);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _inventoryManager.DropItem(ItemsRightHand.nothing ,_moveController);
        }

        _fpsCounter.FPS();
    }

    private void AddControllers()
    {
        MoveController();
        CameraController();
        InteractionController();
        InputController();
        CrouchController();
        StaminaController();


        if (Platforms == PlatformSwitch.Android) {

            _inputController.IsCrouchingAndroidInput(_moveController);
            _inputController.ShowShootButton(_inventoryManager);
            _inputController.FlashliteButtonShow(_inventoryManager);
            _inputController.ShowDropButton(_inventoryManager);

            if (_staminaManager.Stamina() < 1 || _inputController.isCrouch == true) { _inputController.isRunning = false; }
        }
    }

    private void MoveController()
    {
        if (Platforms == PlatformSwitch.PC)
        {
            _moveController.Move(_inputController.PC(_walkSpeed, _runSpeed, _crouchSpeed, Platforms), _gravity);
        }
        else if (Platforms == PlatformSwitch.Android)
        {
            _moveController.Move(_inputController.Android(_walkSpeed, _runSpeed, _crouchSpeed, Platforms), _gravity);
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
        if (Platforms == PlatformSwitch.PC)
        {
            _moveController.CameraInputPC(_lookXSpeed, _lookYSpeed, _lookXLimit);
        }
        else if (Platforms == PlatformSwitch.Android)
        {
            _moveController.CameraInputAndroid(_lookXSpeed, _lookYSpeed, _lookXLimit);
            _fixedTouchField.TouchControllerPlatform();
        }
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
            _interactionManager.HandleInteractionCheck(_interactionDistance);
            _interactionManager.HandleInteractionInput(_inputController.InteractionKey(), _interactionDistance, _interactionLayer);
        }
    }

    private void StaminaController()
    {
        _staminaManager.StaminaSubtraction(_inputController.isRunning, _inputController.isCrouch, 
                                           _moveController.PlayerCharacterController.isGrounded,
                                           _staminaUseMultiplier, _timeBeforeStaminaRegenStarts, _staminaTimeIncrement, _staminaValueIncrement, _maxStamina);
    }

    public void AndroidInteractionInput()
    {
        if (Platforms == PlatformSwitch.Android)
        {
            _interactionManager.InteractionAndroidInput(_interactionDistance, _interactionLayer);
        }
    }

    public void AndroidCrouchInput()
    {
        if (Platforms == PlatformSwitch.Android)
        {
            if (!_moveController.DurringCrouchAnimation)
            {
                StartCoroutine(_moveController.CrouchStand(_standingHeight, _crouchingHeight, _timeToCrouch, _standingCenter, _crouchingCenter));
            }
        }
    }

    public void AndroidRunInput()
    {
        if (Platforms == PlatformSwitch.Android)
        {
            if (_moveController.PlayerCharacterController.isGrounded)
            {
                _inputController.IsRunningAndroidInput(_staminaManager.Stamina());
            }
        }
    }

    public void AndroidFlashliteInput()
    {
        if (Platforms == PlatformSwitch.Android)
        {
            _inputController.FlashLiteAndroidInput();
        }
    }

    public void AndroidDropInput()
    {
        if (Platforms == PlatformSwitch.Android)
        {
            
        }
    }
}
