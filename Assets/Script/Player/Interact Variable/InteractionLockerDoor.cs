using UnityEngine;

public class InteractionLockerDoor : InteractableAbstract
{
    [Header("Angle Setting")]
    [SerializeField] private float _openAngle;
    [SerializeField] private float _closedAngle;
    [SerializeField] private float _speedAnimation;
    [SerializeField] private float _smoothSpeedAnimation = 5;
    [Space]
    [SerializeField] private bool _isLoocked;
    [SerializeField] private LockerVariable _locker;

    public bool IsOpen;

    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "";
    [SerializeField] private string ButtonText = "[E]";

    private void Start()
    {
        ClosedDoor();

        gameObject.tag = "LockedDoor";
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

        if (IsOpen == true)
        {
            transform.localRotation = Quaternion.RotateTowards(currentAngle, Quaternion.Euler(currentAngle.x, _openAngle, currentAngle.z), _speedAnimation / _smoothSpeedAnimation);
        }
        else
        {
            transform.localRotation = Quaternion.RotateTowards(currentAngle, Quaternion.Euler(currentAngle.x, _closedAngle, currentAngle.z), _speedAnimation / _smoothSpeedAnimation);
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
            if (IsOpen == false)
            { IsOpen = true; }
            else { IsOpen = false; }
        }
        else { print("is Locked"); }

        gameObject.layer = 10;
    }
    public override void OnLoseFocus()
    {
        SwitchText.HideText(PlayerController.Platforms);
    }
}
