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
        InteractionFocus.DisableButton();
        Destroy(gameObject);
    }
    public override void OnLoseFocus()
    {
        InteractionFocus.DisableButton();
    }
}
