using UnityEngine;

public abstract class InteractableAbstract : MonoBehaviour
{
    [Space]
    public InventoryManager _inventoryManager;
    public InteractionFocus _interactionFocus;
    public PressKeyInteraction _switchText;
    public Animator _playerAnimator;
    public PlayerController _playerController;

    public virtual void Awake()
    {
        gameObject.layer = 10;

        _inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        _interactionFocus = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InteractionFocus>();
        _switchText = GameObject.FindGameObjectWithTag("PressKey").GetComponent<PressKeyInteraction>();
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public virtual void OnFocus() { }
    public virtual void OnInteractable() { }
    public virtual void OnLoseFocus() { }
}
