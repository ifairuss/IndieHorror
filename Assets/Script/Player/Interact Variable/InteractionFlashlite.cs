using UnityEngine;

public class InteractionFlashlite : InteractableAbstract
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
        _inventoryManager.FlashLitePickUp(true);
        Destroy(gameObject);
        _interactionFocus.DisableButton();
    }
    public override void OnLoseFocus()
    {
        _interactionFocus.DisableButton();
    }
}
