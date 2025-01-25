using Unity.VisualScripting;
using UnityEngine;

public enum LockerVariable
{ 
    None,
    LatticeWindow,
    WoodBrick,
    Rope,
    Wire,
    Codelock,
    Lock

}
public class InteractionLocker : InteractableAbstract
{
    [Header("UI Text Settings")]
    [SerializeField] private string _firstText = "Item";
    [SerializeField] private string _buttonText = "Press [Button]";
    [Header("Locker Variable")]
    [SerializeField] private LockerVariable _lockerVariable;
    [Space]
    [Header("Locker Variable")]
    [SerializeField] private bool _locked;

    public bool Locked => _locked;

    public override void OnFocus()
    {
        SwitchText.ShowText(PlayerController.Platforms);
        SwitchText.SwitchText(_firstText, _buttonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        if (_locked)
        {
            SwitchText.HideText(PlayerController.Platforms);
            DestroyLocker();
        }
    }
    public override void OnLoseFocus()
    {
        SwitchText.HideText(PlayerController.Platforms);
    }

    private void DestroyLocker()
    {

    }
}
