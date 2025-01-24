using UnityEngine;


public enum ItemsRightHand
{
    nothing,
    Revolver,
    Knife,
    Crowbar
}
public class InventoryManager : MonoBehaviour
{
    [Header("Items Setting")]
    [SerializeField] private bool _flashliteThereIs = false;
    [SerializeField] private bool _revolverThereIs = false;
    [SerializeField] private bool _knifeThereIs = false;
    [SerializeField] private bool _crowbarThereIs = false;
    [Space]
    [SerializeField] private GameObject RevolverPrefab;
    [SerializeField] private GameObject KnifePrefab;
    [SerializeField] private GameObject CrowbarPrefab;

    public ItemsRightHand RightHandItems;
    public GameObject RightHandGameObject;

    public bool Flashlite => _flashliteThereIs;

    public void FlashLitePickUp(bool flashLite)
    {
        _flashliteThereIs = flashLite;
    }
}
