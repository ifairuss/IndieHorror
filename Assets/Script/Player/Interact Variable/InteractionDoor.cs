using TMPro;
using UnityEngine;

public class InteractionDoor : InteractableAbstract
{
    [Header("Door Config")]
    [SerializeField] private TextMeshProUGUI _interactionButton;
    [SerializeField] private bool _isOpenDoor;

    private Animator _animatorDoor;

    private void Start()
    {
        _interactionButton.gameObject.SetActive(false);

        _animatorDoor = GetComponent<Animator>();

        _isOpenDoor = false;
    }

    public override void OnFocus()
    {
        _interactionButton.gameObject.SetActive(true);
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
        _interactionButton.gameObject.SetActive(false);
    }
}
