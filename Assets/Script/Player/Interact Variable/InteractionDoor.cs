using UnityEngine;

public class InteractionDoor : InteractableAbstract
{   
    [SerializeField] private bool _isOpenDoor;

    private Animator _animatorDoor;

    private void Start()
    {
        _animatorDoor = GetComponent<Animator>();
    }

    public override void OnFocus()
    {
        _interactionFocus.ActiveButton();
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
