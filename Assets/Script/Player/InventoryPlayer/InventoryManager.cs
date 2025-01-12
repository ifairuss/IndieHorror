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
    public bool Revolver => _revolverThereIs;
    public bool Knife => _knifeThereIs;
    public bool Crowbar => _crowbarThereIs;

    public void FlashLitePickUp(bool flashLite)
    {
        _flashliteThereIs = flashLite;
    }

    public void PickUpItems(ItemsRightHand variableItems)
    {
        RightHandItems = variableItems;

        switch (RightHandItems)
        {
            case ItemsRightHand.nothing:
                _revolverThereIs = false;
                _knifeThereIs = false;
                _crowbarThereIs = false;
                //-------------------------
                RightHandGameObject = null;
                break;
            case ItemsRightHand.Revolver:
                _revolverThereIs = true;
                _knifeThereIs = false;
                _crowbarThereIs = false;
                //-------------------------
                RightHandGameObject = RevolverPrefab;
                break;
            case ItemsRightHand.Knife:
                _knifeThereIs = true;
                _revolverThereIs = false;
                _crowbarThereIs = false;
                //------------------------
                RightHandGameObject = KnifePrefab;
                break;
            case ItemsRightHand.Crowbar:
                _crowbarThereIs = true;
                _knifeThereIs = false;
                _revolverThereIs = false;
                //------------------------
                RightHandGameObject = CrowbarPrefab;
                break;
        }
    }
}
