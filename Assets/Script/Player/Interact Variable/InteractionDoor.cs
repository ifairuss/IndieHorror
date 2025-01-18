using UnityEngine;

public class InteractionDoor : InteractableAbstract
{
    [Header("Angle Setting")]
    [SerializeField] private float _openAngle;
    [SerializeField] private float _closedAngle;
    [SerializeField] private float _speedAnimation;
    [Space]
    [SerializeField] private bool _isLoockedDoor;
    [SerializeField] private bool _isOpenDoor;
    [SerializeField] private KeyVariable _key;
    [SerializeField] private LockerVariable _locker;

    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "";
    [SerializeField] private string ButtonText = "[E]";

    private void Update()
    {
        DoorAnimation();
    }

    private void DoorAnimation()
    {
        Quaternion currentAngle = transform.localRotation;

        if (_isOpenDoor == true)
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
        InteractionFocus.ActiveButton();
        SwitchText.SwitchText(FirstText, ButtonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        if (!_isLoockedDoor)
        {
            if (_isOpenDoor == false) 
                 {_isOpenDoor = true;}
            else {_isOpenDoor = false;}
        }
        else
        {

        }
    }
    public override void OnLoseFocus()
    {
        InteractionFocus.DisableButton();
    }
}
