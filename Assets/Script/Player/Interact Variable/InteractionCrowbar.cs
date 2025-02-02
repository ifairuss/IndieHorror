using UnityEngine;

public class InteractionCrowbar : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "item";
    [SerializeField] private string ButtonText = "Press [Button]";

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
        InventoryManager.PickUpItem(ItemsRightHand.Crowbar);
        SwitchText.HideText(PlayerController.Platforms);
        Destroy(gameObject);
    }
    public override void OnLoseFocus()
    {
        SwitchText.HideText(PlayerController.Platforms);
    }
}
