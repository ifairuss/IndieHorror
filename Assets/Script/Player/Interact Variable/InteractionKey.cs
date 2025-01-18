using UnityEngine;

public class InteractionKey : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string _firstText = "First";
    [SerializeField] private string _buttonText = "Button";

    public override void OnFocus()
    {
        InteractionFocus.ActiveButton();
        SwitchText.SwitchText(_firstText, _buttonText, PlayerController.Platforms);
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
