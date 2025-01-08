using System.Collections;
using UnityEngine;

public class InteractionDoor : InteractableAbstract
{
    [Header("Door Setting")]
    [Space]
    [SerializeField] private bool _isLoockedDoor;
    [SerializeField] private bool _isOpenDoor;
    [SerializeField] private KeyVariable _key;

    [Header("UI Text Settings")]
    [SerializeField] private string FirstText = "";
    [SerializeField] private string ButtonText = "[E]";

    public override void OnFocus()
    {
        InteractionFocus.ActiveButton();
        SwitchText.SwitchText(FirstText, ButtonText, PlayerController.Platforms);
    }
    public override void OnInteractable()
    {
        if (!_isLoockedDoor)
        {
            if (_isOpenDoor == false)
            {
            }
            else
            {
            }
        }
        else
        {
            UnlockDoor();
        }
    }
    public override void OnLoseFocus()
    {
        InteractionFocus.DisableButton();
    }

    private void UnlockDoor()
    {
        switch (_key)
        {
            case KeyVariable.Kitchen:
                if (KeyManager.Kitchen)
                    _isLoockedDoor = false;
                break;
            case KeyVariable.House:
                if (KeyManager.House)
                    _isLoockedDoor = false;
                break;
            case KeyVariable.Basement:
                if (KeyManager.Basement)
                    _isLoockedDoor = false;
                break;
            case KeyVariable.Ritual:
                if (KeyManager.Ritual)
                    _isLoockedDoor = false;
                break;
            case KeyVariable.SummerKitchen:
                if (KeyManager.SummerKitchen)
                    _isLoockedDoor = false;
                break;
        }

        if (_isLoockedDoor)
        {
            print($"{FirstText} closed");
        }
    }
}
