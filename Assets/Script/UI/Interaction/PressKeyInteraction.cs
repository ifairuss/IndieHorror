using TMPro;
using UnityEngine;

public class PressKeyInteraction : MonoBehaviour
{
    [Header("UI Key Setting")]
    [SerializeField] private TextMeshProUGUI _firstText;
    [SerializeField] private TextMeshProUGUI _buttonText;

    public void SwitchText(string firstText, string buttonText, PlatformSwitch platform)
    {
        _firstText.text = firstText;
        
        if(platform == PlatformSwitch.PC)
        {
            _buttonText.text = buttonText;
            _buttonText.gameObject.SetActive(true);
        }
        else
        {
            _buttonText.gameObject.SetActive(false);
        }
    }
}
