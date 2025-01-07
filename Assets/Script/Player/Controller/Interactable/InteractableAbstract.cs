using UnityEngine;

public abstract class InteractableAbstract : MonoBehaviour
{
    [Space]
    public InventoryManager InventoryManager;
    public InteractionFocus InteractionFocus;
    public PressKeyInteraction SwitchText;
    public Animator PlayerAnimator;
    public PlayerController PlayerController;
    public KeyManager KeyManager;

    public virtual void Awake()
    {
        gameObject.layer = 10;

        InventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        InteractionFocus = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InteractionFocus>();
        KeyManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<KeyManager>();
        SwitchText = GameObject.FindGameObjectWithTag("PressKey").GetComponent<PressKeyInteraction>();
        PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public virtual void OnFocus() { }
    public virtual void OnInteractable() { }
    public virtual void OnLoseFocus() { }
}
