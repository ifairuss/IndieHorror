using UnityEngine;

public class InteractionCrowbar : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "item";
    [SerializeField] private string ButtonText = "Press [Button]";


    public override void OnFocus()
    {
        InteractionFocus.ActiveButton();
        SwitchText.SwitchText(FirstText, ButtonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        if (InventoryManager.RightHandGameObject != null)
        {
            Instantiate(InventoryManager.RightHandGameObject, PlayerController.transform.position + Vector3.up * 2f + PlayerController.transform.forward * 5f, Quaternion.Euler(0, 0, 90));

        }
        InventoryManager.PickUpItems(ItemsRightHand.Crowbar);
        InteractionFocus.DisableButton();
        Destroy(gameObject);
    }
    public override void OnLoseFocus()
    {
        InteractionFocus.DisableButton();
    }
}
