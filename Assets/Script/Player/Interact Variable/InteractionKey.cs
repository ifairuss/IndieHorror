using UnityEngine;

public enum KeyVariable
{
    None,
    Kitchen,
    House,
    Basement,
    Ritual,
    SummerKitchen
}

public class InteractionKey : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string _firstText = "First";
    [SerializeField] private string _buttonText = "Button";
    [Header("Key Variable")]
    [SerializeField] private KeyVariable _keyVariable;

    public override void OnFocus()
    {
        InteractionFocus.ActiveButton();
        SwitchText.SwitchText(_firstText, _buttonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        KeyManager.PickUpKey(_keyVariable);
        InteractionFocus.DisableButton();
        Destroy(gameObject);
    }
    public override void OnLoseFocus()
    {
        InteractionFocus.DisableButton();
    }
}
