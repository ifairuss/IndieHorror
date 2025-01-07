using UnityEngine;

public class InteractionFlashlite : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "First";
    [SerializeField] private string ButtonText = "Button";

    public override void OnFocus()
    {
        InteractionFocus.ActiveButton();
        SwitchText.SwitchText(FirstText, ButtonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        InventoryManager.FlashLitePickUp(true);
        InteractionFocus.DisableButton();
        Destroy(gameObject);
    }
    public override void OnLoseFocus()
    {
        InteractionFocus.DisableButton();
    }
}
