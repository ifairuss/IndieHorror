using UnityEngine;

public enum KeyVariable
{
    None,
    Kitchen,
    House,
    Basement,
    Ritual,
    SummerKitchen
}
public class KeyManager : MonoBehaviour
{
    [Header("Key Setting")]
    [SerializeField] private bool _kitchenKey;
    [SerializeField] private bool _houseKey;
    [SerializeField] private bool _basementKey;
    [SerializeField] private bool _ritualKey;
    [SerializeField] private bool _summerKitchenKey;
}
