using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    private Image _rightSlider;
    private Image _leftSlider;

    private void Start()
    {
        _rightSlider = transform.GetChild(0).GetComponent<Image>();
        _leftSlider = transform.GetChild(1).GetComponent<Image>();

        _rightSlider.gameObject.SetActive(false);
        _leftSlider.gameObject.SetActive(false);
    }

    public void OnStaminaSlider(float currentStamina)
    {
        _rightSlider.gameObject.SetActive(true);
        _leftSlider.gameObject.SetActive(true);

        if(currentStamina <= 0.01) {
            _rightSlider.gameObject.SetActive(false);
            _leftSlider.gameObject.SetActive(false);
        }
        else {
            _rightSlider.gameObject.SetActive(true);
            _leftSlider.gameObject.SetActive(true);
        }

        _rightSlider.fillAmount = currentStamina;
        _leftSlider.fillAmount = currentStamina;
    }

    public void OffStaminaSlider()
    {
        _rightSlider.gameObject.SetActive(false);
        _leftSlider.gameObject.SetActive(false);
    }
}
