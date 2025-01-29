using UnityEngine;

public class InteractionLockerDoor : InteractableAbstract
{
    [Header("Angle Setting")]
    [SerializeField] private float _openAngle;
    [SerializeField] private float _closedAngle;
    [SerializeField] private float _speedAnimation;
    [Space]
    [SerializeField] private bool _isLoocked;
    [SerializeField] private bool _isOpen;
    [SerializeField] private LockerVariable _locker;

    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "";
    [SerializeField] private string ButtonText = "[E]";

    private void Start()
    {
        ClosedDoor();
    }

    private void Update()
    {
        DoorAnimation();
    }

    private void ClosedDoor()
    {
        if (_locker != LockerVariable.None) { _isLoocked = false; }
        else { _isLoocked = true; }
    }

    private void DoorAnimation()
    {
        Quaternion currentAngle = transform.localRotation;

        if (_isOpen == true)
        {
            transform.localRotation = Quaternion.Slerp(currentAngle, Quaternion.Euler(currentAngle.x, _openAngle, currentAngle.z), _speedAnimation * Time.unscaledDeltaTime);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(currentAngle, Quaternion.Euler(currentAngle.x, _closedAngle, currentAngle.z), _speedAnimation * Time.unscaledDeltaTime);
        }
    }

    public override void OnFocus()
    {
        SwitchText.ShowText(PlayerController.Platforms);
        SwitchText.SwitchText(FirstText, ButtonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        if (!_isLoocked) {  }

        if (_isLoocked)
        {
            if (_isOpen == false)
            { _isOpen = true; }
            else { _isOpen = false; }
        }
        else { print("is Locked"); }

        gameObject.layer = 10;
    }
    public override void OnLoseFocus()
    {
        SwitchText.HideText(PlayerController.Platforms);
    }
}
