using UnityEngine;

public class InteractionFlashlite : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "First";
    [SerializeField] private string ButtonText = "Button";

    public override void OnFocus()
    {
        SwitchText.ShowText(PlayerController.Platforms);
        SwitchText.SwitchText(FirstText, ButtonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        InventoryManager.FlashLitePickUp(true);
        SwitchText.HideText(PlayerController.Platforms);
        Destroy(gameObject);
    }
    public override void OnLoseFocus()
    {
        SwitchText.HideText(PlayerController.Platforms);
    }
}
