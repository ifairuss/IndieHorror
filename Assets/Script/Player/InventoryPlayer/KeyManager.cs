using System.Collections.Generic;
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

    public Dictionary<KeyVariable, bool> KeyVariables = new Dictionary<KeyVariable, bool>();

    private void Start()
    {
        KeyVariables.Add(KeyVariable.Kitchen, _kitchenKey);
        KeyVariables.Add(KeyVariable.House, _houseKey);
        KeyVariables.Add(KeyVariable.Basement, _basementKey);
        KeyVariables.Add(KeyVariable.Ritual, _ritualKey);
        KeyVariables.Add(KeyVariable.SummerKitchen, _summerKitchenKey);
    }

    public bool KeyUnlock(KeyVariable variableKey)
    {
        switch (variableKey)
        {
            case KeyVariable.Kitchen:
                _kitchenKey = true;
                KeyVariables[KeyVariable.Kitchen] = _kitchenKey;
                return _kitchenKey;
            case KeyVariable.House:
                _houseKey = true;
                KeyVariables[KeyVariable.House] = _houseKey;
                return _houseKey;
            case KeyVariable.Basement:
                _basementKey = true;
                KeyVariables[KeyVariable.Basement] = _basementKey;
                return _basementKey;
            case KeyVariable.Ritual:
                _ritualKey = true;
                KeyVariables[KeyVariable.Ritual] = _ritualKey;
                return _ritualKey;
            case KeyVariable.SummerKitchen:
                _summerKitchenKey = true;
                KeyVariables[KeyVariable.SummerKitchen] = _summerKitchenKey;
                return _summerKitchenKey;
            default:
                return false;
        }
    }
}
