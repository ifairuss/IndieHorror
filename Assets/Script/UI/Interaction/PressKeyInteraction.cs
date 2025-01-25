using TMPro;
using UnityEngine;

public class PressKeyInteraction : MonoBehaviour
{
    [Header("UI Key Setting")]
    [SerializeField] private TextMeshProUGUI _firstText;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private void Start()
    {
        _firstText.alpha = 0;
        _buttonText.alpha = 0;
    }

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

    public void HideText(PlatformSwitch platform)
    {
        if (platform == PlatformSwitch.Android)
        {
            _firstText.alpha = 0;
        }
        else
        {
            _firstText.alpha = 0;
            _buttonText.alpha = 0;
        }
    }

    public void ShowText(PlatformSwitch platform)
    {
        if (platform == PlatformSwitch.Android)
        {
            _firstText.alpha = 1;
        }
        else
        {
            _firstText.alpha = 1;
            _buttonText.alpha = 1;
        }
    }
}
