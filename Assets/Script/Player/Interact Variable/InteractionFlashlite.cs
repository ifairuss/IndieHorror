public class InteractionFlashlite : InteractableAbstract
{
    public override void OnFocus()
    {
        _interactionFocus.ActiveButton();
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
