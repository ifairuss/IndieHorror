using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [Header("Key Setting")]
    [SerializeField] private bool _kitchenKey;
    [SerializeField] private bool _houseKey;
    [SerializeField] private bool _basementKey;
    [SerializeField] private bool _ritualKey;
    [SerializeField] private bool _summerKitchenKey;

    public bool Kitchen => _kitchenKey;
    public bool House => _houseKey;
    public bool Basement => _basementKey;
    public bool Ritual => _ritualKey;
    public bool SummerKitchen => _summerKitchenKey;

    public bool GrillLocker;

    public void PickUpKey(KeyVariable keyVariable)
    {
        KeyVariable key = keyVariable;

        switch (key)
        {
            case KeyVariable.Kitchen:
                _kitchenKey = true;
                    break;
            case KeyVariable.House:
                _houseKey = true;
                break;
            case KeyVariable.Basement:
                _basementKey = true;
                break;
            case KeyVariable.Ritual:
                _ritualKey = true;
                break;
            case KeyVariable.SummerKitchen:
                _summerKitchenKey = true;
                break;
            default:
                break;
        }

    }
}
