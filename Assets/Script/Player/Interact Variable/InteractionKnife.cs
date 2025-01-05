using UnityEngine;

public class InteractionKnife : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "First";
    [SerializeField] private string ButtonText = "Button";

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
        if (_inventoryManager.RightHandGameObject != null)
        {
            Instantiate(_inventoryManager.RightHandGameObject, _playerController.transform.position + Vector3.up * 2f + _playerController.transform.forward * 5f, Quaternion.Euler(0, 0, 90));
        }
        _inventoryManager.PickUpItems(ItemsRightHand.Knife);
        _interactionFocus.DisableButton();
        Destroy(gameObject);
    }
    public override void OnLoseFocus()
    {
        _interactionFocus.DisableButton();
    }
}
