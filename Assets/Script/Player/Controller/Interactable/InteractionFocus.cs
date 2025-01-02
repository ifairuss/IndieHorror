using TMPro;
using UnityEngine;

public class InteractionFocus : MonoBehaviour
{
    private RectTransform InteractionButton;

    private void Start()
    {
        InteractionButton = GameObject.FindGameObjectWithTag("PressKey").GetComponent<RectTransform>();
        InteractionButton.gameObject.SetActive(false);
    }

    public void ActiveButton()
    {
        InteractionButton.gameObject.SetActive(true);
    }

    public void DisableButton()
    {
        InteractionButton.gameObject.SetActive(false);
    }
}
