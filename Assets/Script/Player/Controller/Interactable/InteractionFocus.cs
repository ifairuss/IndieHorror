using UnityEngine;

public class InteractionFocus : MonoBehaviour
{
    private RectTransform InteractionButtonText;

    private void Start()
    {
        InteractionButtonText = GameObject.FindGameObjectWithTag("PressKey").GetComponent<RectTransform>();
        InteractionButtonText.gameObject.SetActive(false);
    }

    public void ActiveButton()
    {
        InteractionButtonText.gameObject.SetActive(true);
    }

    public void DisableButton()
    {
        InteractionButtonText.gameObject.SetActive(false);
    }
}
