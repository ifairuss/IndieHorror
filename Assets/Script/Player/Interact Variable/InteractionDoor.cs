using UnityEngine;

public class InteractionDoor : InteractableAbstract
{   
    [SerializeField] private bool _isOpenDoor;

    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "";
    [SerializeField] private string ButtonText = "[E]";

    private Animator _animatorDoor;

    private void Start()
    {
        _animatorDoor = GetComponent<Animator>();
    }

    public override void OnFocus()
    {
        if (_playerController.Platforms == PlatformSwitch.PC)
        {
            _interactionFocus.ActiveButton();
            _switchText.SwitchText(FirstText, ButtonText);
        }
    }
    public override void OnInteractable()
    {
        if(_isOpenDoor == false)
        {
            _animatorDoor.SetBool("isDoorOpen", true);
            _isOpenDoor = true;
        }
        else
        {
            _animatorDoor.SetBool("isDoorOpen", false);
            _isOpenDoor = false;
        }
    }
    public override void OnLoseFocus()
    {
        _interactionFocus.DisableButton();
    }
}
