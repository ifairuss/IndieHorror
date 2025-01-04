using System.Collections;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    private float _currentStamina;
    private Coroutine _regenerationStamina;
    private StaminaSlider _slider;

    private void Start()
    {
        _slider = GameObject.FindGameObjectWithTag("StaminaUI").GetComponent<StaminaSlider>();

        _currentStamina = 100f;
    }

    public float Stamina()
    {
        return _currentStamina;
    }

    public void StaminaSubtraction(bool isRunning, bool isCrouch, bool isGround,
                                   float staminaUseMultiplier, float timeBeforeStaminaRegenStarts, float staminaTimeIncrement, float staminaValueIncrement, float maxStamina)
    {
        if (isRunning && _currentStamina > 0 && !isCrouch && isGround)
        {
            if (_regenerationStamina != null)
            {
                StopCoroutine(_regenerationStamina);
                _regenerationStamina = null;
            }
            _currentStamina -= staminaUseMultiplier * Time.deltaTime;

            if (_currentStamina < maxStamina)
            {
                _slider.OnStaminaSlider(_currentStamina / 100);
            }

            _currentStamina = Mathf.Clamp(_currentStamina, 0 ,maxStamina);
        }

        if (!isRunning && _currentStamina < maxStamina && _regenerationStamina == null)
        {
            _regenerationStamina = StartCoroutine(RegenerationStamina(timeBeforeStaminaRegenStarts, staminaTimeIncrement, staminaValueIncrement, maxStamina));
        }
    }

    private IEnumerator RegenerationStamina(float timeBeforeStaminaRegenStarts, float staminaTimeIncrement, float staminaValueIncrement, float maxStamina)
    {
        yield return new WaitForSeconds(timeBeforeStaminaRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(staminaTimeIncrement);

        while (_currentStamina < maxStamina)
        {
            _currentStamina += staminaValueIncrement;

            if (_currentStamina < maxStamina)
            {
                _slider.OnStaminaSlider(_currentStamina / 100);
            }
            else
            {
                _slider.OffStaminaSlider();
            }

            _currentStamina = Mathf.Clamp(_currentStamina, 0, maxStamina);

            yield return timeToWait;
        }

        _regenerationStamina = null;
    }
}
