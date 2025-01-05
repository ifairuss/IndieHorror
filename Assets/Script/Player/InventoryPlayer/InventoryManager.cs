using UnityEngine;


public enum ItemsRightHand
{
    nothing,
    Revolver,
    Knife
}
public class InventoryManager : MonoBehaviour
{
    [Header("Items Setting")]
    [SerializeField] private bool _flashliteThereIs = false;
    [SerializeField] private bool _revolverThereIs = false;
    [SerializeField] private bool _knifeThereIs = false;
    [Space]
    [SerializeField] private GameObject RevolverPrefab;
    [SerializeField] private GameObject KnifePrefab;

    public ItemsRightHand RightHandItems;
    public GameObject RightHandGameObject;

    public bool Flashlite => _flashliteThereIs;
    public bool Revolver => _revolverThereIs;

    public bool Knife => _knifeThereIs;

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
                RightHandGameObject = null;
                _knifeThereIs = false;
                break;
            case ItemsRightHand.Revolver:
                _revolverThereIs = true;
                RightHandGameObject = RevolverPrefab;
                _knifeThereIs = false;
                break;
            case ItemsRightHand.Knife:
                _knifeThereIs = true;
                RightHandGameObject = KnifePrefab;
                _revolverThereIs = false;
                break;
        }
    }
}
