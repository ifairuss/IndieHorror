using TMPro;
using UnityEngine;

public class PressKeyInteraction : MonoBehaviour
{
    [Header("UI Key Setting")]
    [SerializeField] private TextMeshProUGUI _firstText;
    [SerializeField] private TextMeshProUGUI _buttonText;

    public void SwitchText(string firstText, string buttonText)
    {
        _firstText.text = firstText;
        _buttonText.text = buttonText;
    }
}
