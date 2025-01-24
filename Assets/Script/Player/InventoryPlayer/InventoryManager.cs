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

    public GameObject RightHandGameObject;

    public bool Flashlite => _flashliteThereIs;
    public bool Revolver => _revolverThereIs;
    public bool Knife => _knifeThereIs;
    public bool Crowbar => _crowbarThereIs;

    public void PickUpItem(ItemsRightHand items)
    {
        switch (items)
        {
            default:
            case ItemsRightHand.nothing:
                _revolverThereIs = false;
                _knifeThereIs = false;
                _crowbarThereIs = false;

                RightHandGameObject = null;
                break;
            case ItemsRightHand.Revolver:
                _revolverThereIs = true;
                _knifeThereIs = false;
                _crowbarThereIs = false;

                RightHandGameObject = RevolverPrefab;
                break;
            case ItemsRightHand.Knife:
                _revolverThereIs = false;
                _knifeThereIs = true;
                _crowbarThereIs = false;

                RightHandGameObject = KnifePrefab;
                break;
            case ItemsRightHand.Crowbar:
                _revolverThereIs = false;
                _knifeThereIs = false;
                _crowbarThereIs = true;

                RightHandGameObject = CrowbarPrefab;
                break;
        }
    }

    public void DropItem(ItemsRightHand items, Movement movement)
    {
        if (RightHandGameObject == null) { return; }

        Instantiate(RightHandGameObject, movement.PlayerCharacterController.transform.position + Vector3.up * 2 + Vector3.forward * 5, Quaternion.Euler(0, 0, 90));
        RightHandGameObject = null;
    }

    public void FlashLitePickUp(bool flashLite)
    {
        _flashliteThereIs = flashLite;
    }
}
