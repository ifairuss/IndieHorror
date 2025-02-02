using UnityEngine;

public class InteractionKnife : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "First";
    [SerializeField] private string ButtonText = "Button";

    private void Start()
    {
        gameObject.layer = 12;
    }

    public override void OnFocus()
    {
        SwitchText.ShowText(PlayerController.Platforms);
        SwitchText.SwitchText(FirstText, ButtonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        InventoryManager.DropItem(ItemsRightHand.nothing, PlayerController);
        InventoryManager.PickUpItem(ItemsRightHand.Knife);
        SwitchText.HideText(PlayerController.Platforms);
        Destroy(gameObject);
    }
    public override void OnLoseFocus()
    {
        SwitchText.HideText(PlayerController.Platforms);
    }
}
