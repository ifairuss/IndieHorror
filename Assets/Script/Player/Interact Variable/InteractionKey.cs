using UnityEngine;

public class InteractionKey : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string _firstText = "First";
    [SerializeField] private string _buttonText = "Button";
    [SerializeField] private KeyVariable _keyVariable;

    private void Start()
    {
        gameObject.layer = 12;
    }

    public override void OnFocus()
    {
        SwitchText.ShowText(PlayerController.Platforms);
        SwitchText.SwitchText(_firstText, _buttonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        KeyManager.KeyUnlock(_keyVariable);
        SwitchText.HideText(PlayerController.Platforms);
        Destroy(gameObject);
    }
    public override void OnLoseFocus()
    {
        SwitchText.HideText(PlayerController.Platforms);
    }


}
