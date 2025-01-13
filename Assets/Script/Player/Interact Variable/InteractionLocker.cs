using Unity.VisualScripting;
using UnityEngine;

public enum LockerVariable
{ 
    None,
    GrillWindow
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
        InteractionFocus.ActiveButton();
        SwitchText.SwitchText(_firstText, _buttonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        if (_locked)
        {
            DestroyLocker();
        }
        InteractionFocus.DisableButton();
    }
    public override void OnLoseFocus()
    {
        InteractionFocus.DisableButton();
    }

    private void DestroyLocker()
    {
        if (InventoryManager.Crowbar == true)
        {
            Rigidbody rb = transform.AddComponent<Rigidbody>();
            rb.mass = 50f;
            rb.AddForce(Vector3.forward * 3, ForceMode.Impulse);
            gameObject.layer = 0;
            _locked = false;
            KeyManager.GrillLocker = true;
        }
    }
}
