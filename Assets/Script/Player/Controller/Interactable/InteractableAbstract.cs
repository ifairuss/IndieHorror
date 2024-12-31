using UnityEngine;

public abstract class InteractableAbstract : MonoBehaviour
{
    public virtual void Awake()
    {
        gameObject.layer = 10;
    }

    public virtual void OnFocus() { }
    public virtual void OnInteractable() { }
    public virtual void OnLoseFocus() { }
}
