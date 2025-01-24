using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    //------------------------------PC Button-------------------------------------
    [Header("Controll Setting")]
    [SerializeField] private KeyCode _runInput = KeyCode.LeftShift;
    [SerializeField] private KeyCode _crouchInput = KeyCode.C;
    [SerializeField] private KeyCode _flashLite = KeyCode.F;
    [SerializeField] private KeyCode _interaction = KeyCode.E;

    // Ctr + K and Ctr + C -- Comments
    // Ctr + K and Ctr + U -- UnComments

    //------------------------------Android Button-------------------------------------
    [Space]
    [Header("Controll Android Setting")]
    [SerializeField] private Image _runAndroidInput;
    [SerializeField] private Image _dropAndroidInput;
    [SerializeField] private Image _crouchAndroidInput;
    [SerializeField] private Image _shootAndroidInput;
    [SerializeField] private Image _flashLiteAndroidInput;
    [Space]
    [Header("Sprite Android Setting")]
    [SerializeField] private Sprite _runAndroidSpriteTrue;
    [SerializeField] private Sprite _runAndroidSpriteFalse;
    [SerializeField] private Sprite _flashLiteAndroidSpriteOn;
    [SerializeField] private Sprite _flashLiteAndroidSpriteOff;
    [Space]

    private Joystick _joystick;
    private RectTransform _androidUI;

    private Vector3 _hitSlopeNormal;

    //------------------------------------------------------------------------

    [Header("Preferences")]
    public Vector3 MoveDirection = Vector3.zero;

    public bool isRunning;
    public bool isCrouch;
    public bool isFlashlite;

    private float _timerInput = 0.5f;

    private void Start()
    {
        _joystick = GameObject.FindGameObjectWithTag("Android").GetComponentInChildren<Joystick>();
        _androidUI = GameObject.FindGameObjectWithTag("Android").GetComponent<RectTransform>();

        DisableButtonAtStart();
    }

    private void DisableButtonAtStart()
    {
        _flashLiteAndroidInput.gameObject.SetActive(false);
        _shootAndroidInput.gameObject.SetActive(false);
        _dropAndroidInput.gameObject.SetActive(false);
    }

    //----------------------------PC----------------------------
    public Vector3 PC(float walkSpeed, float runSpeed, float crouchSpeed, PlatformSwitch platform)
    {
        if (platform == PlatformSwitch.PC)
        {
            _androidUI.gameObject.SetActive(false);
        }

        float directionY = (isCrouch ? crouchSpeed : isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
        float directionX = (isCrouch ? crouchSpeed : isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");

        MoveDirection = (transform.TransformDirection(Vector3.forward) * directionX)
                        + (transform.TransformDirection(Vector3.right) * directionY);

        return MoveDirection * Time.deltaTime;
    }

    public void RuningStaminaCheck(float currentSprint)
    {
        isRunning = Input.GetKey(_runInput) && !isCrouch && currentSprint > 1;
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

    //----------------------------Android----------------------------

    public Vector3 Android(float walkSpeed, float runSpeed, float crouchSpeed, PlatformSwitch platform)
    {
        if (platform == PlatformSwitch.PC)
        {
            _androidUI.gameObject.SetActive(true);
        }

        float directionY = (isCrouch ? crouchSpeed : isRunning ? runSpeed : walkSpeed) * _joystick.Horizontal;
        float directionX = (isCrouch ? crouchSpeed : isRunning ? runSpeed : walkSpeed) * _joystick.Vertical;

        MoveDirection = (transform.TransformDirection(Vector3.forward) * directionX)
                        + (transform.TransformDirection(Vector3.right) * directionY);

        return MoveDirection * Time.deltaTime;
    }

    public void IsCrouchingAndroidInput(Movement _movement)
    {
        isCrouch = _movement.isCrouching;
    }

    public void IsRunningAndroidInput(float currentSprint)
    {
        if (currentSprint > 1 && !isCrouch)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    public void FlashLiteAndroidInput()
    {
        if (isFlashlite == false)
        {
            isFlashlite = true;
            _flashLiteAndroidInput.sprite = _flashLiteAndroidSpriteOn;
        }
        else if (isFlashlite == true)
        {
            isFlashlite = false;
            _flashLiteAndroidInput.sprite = _flashLiteAndroidSpriteOff;
        }
    }

    public void FlashliteButtonShow(InventoryManager inventory)
    {
        if (inventory.Flashlite == true)
        {
            _flashLiteAndroidInput.gameObject.SetActive(true);
        }
    }
    public void ShowShootButton(InventoryManager inventory)
    {
        //if (inventory.Revolver == true)
        //{
        //    _shootAndroidInput.gameObject.SetActive(true);
        //}
        //else
        //{
        //    _shootAndroidInput.gameObject.SetActive(false);
        //}
    }

    public void ShowDropButton(InventoryManager inventory)
    {
        if (inventory.RightHandGameObject != null)
        {
            _dropAndroidInput.gameObject.SetActive(true);
        }
        else
        {
            _dropAndroidInput.gameObject.SetActive(false);
        }
    }
}
