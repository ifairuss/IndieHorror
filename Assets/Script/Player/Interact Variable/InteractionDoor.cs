using UnityEngine;

public class InteractionDoor : InteractableAbstract
{
    [Header("Angle Setting")]
    [SerializeField] private float _openAngle;
    [SerializeField] private float _closedAngle;
    [SerializeField] private float _speedAnimation;
    [SerializeField] private float _smoothSpeedAnimation = 2f;
    [Space]
    [SerializeField] private bool _isLoockedDoor;
    [SerializeField] private KeyVariable _key;
    [SerializeField] private LockerVariable _locker;

    public bool IsOpenDoor;

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
        if (_key != KeyVariable.None) { _isLoockedDoor = false; }
        else { _isLoockedDoor = true;}
    }

    private void DoorAnimation()
    {
        Quaternion currentAngle = transform.localRotation;

        if (IsOpenDoor == true)
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
        if (!_isLoockedDoor) { _isLoockedDoor = KeyManager.KeyVariables[_key]; }

        if (_isLoockedDoor)
        {
            if (IsOpenDoor == false)
            { IsOpenDoor = true; }
            else { IsOpenDoor = false; }
        }
        else { print("No key"); }

        gameObject.layer = 10;
    }
    public override void OnLoseFocus()
    {
        SwitchText.HideText(PlayerController.Platforms);
    }
}
