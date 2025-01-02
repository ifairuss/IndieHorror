using UnityEngine;

public abstract class InteractableAbstract : MonoBehaviour
{
    public InventoryManager _inventoryManager;
    public InteractionFocus _interactionFocus;
    public Animator _playerAnimator;

    public virtual void Awake()
    {
        gameObject.layer = 10;

        _inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        _interactionFocus = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InteractionFocus>();
    }

    public virtual void OnFocus() { }
    public virtual void OnInteractable() { }
    public virtual void OnLoseFocus() { }
}
