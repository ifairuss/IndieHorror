using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Items Setting")]
    [SerializeField] private bool _flashliteThereIs = false;

    public bool Flashlite => _flashliteThereIs;

    public void FlashLitePickUp(bool flashLite)
    {
        _flashliteThereIs = flashLite;
    }
}
