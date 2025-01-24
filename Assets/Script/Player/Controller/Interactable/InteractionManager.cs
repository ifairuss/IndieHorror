using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("Interaction Preferences")]
    [SerializeField] private GameObject _interactionButton;

    private Camera _playerCamera;
    private InteractableAbstract _currentInteraction;

    private void Start()
    {
        _playerCamera = GetComponentInChildren<Camera>();
        _interactionButton.SetActive(false);
    }

    public void HandleInteractionCheck(float interactionDistance)
    {
        Debug.DrawRay(_playerCamera.transform.position, _playerCamera.transform.forward * interactionDistance, Color.red);

        if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out RaycastHit hit, interactionDistance) && hit.collider.gameObject.layer == 10)
        {
            Debug.DrawRay(_playerCamera.transform.position, _playerCamera.transform.forward * interactionDistance, Color.green);

            if (hit.collider.gameObject.layer == 10 && (_currentInteraction == null || hit.collider.gameObject.GetInstanceID() != _currentInteraction.GetInstanceID()))
            {
                hit.collider.TryGetComponent(out _currentInteraction);

                if (_currentInteraction)
                {
                    _interactionButton.SetActive(true);
                    _currentInteraction.OnFocus();
                }
            }
        }
        else if (_currentInteraction)
        {
            _interactionButton.SetActive(false);
            _currentInteraction.OnLoseFocus();
            _currentInteraction = null;
        }
    }

    public void HandleInteractionInput(KeyCode interactionKey, float interactionDistance, LayerMask interactionLayer)
    {
        if (Input.GetKeyDown(interactionKey) && _currentInteraction != null && Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, interactionDistance, interactionLayer))
        {
            if (_currentInteraction.PlayerController.Platforms == PlatformSwitch.PC)
            {
                _currentInteraction.OnInteractable();
            }
        }
    }

    public void InteractionAndroidInput(float interactionDistance, LayerMask interactionLayer)
    {
        if (_currentInteraction != null && Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, interactionDistance, interactionLayer))
        {
            if (_currentInteraction.PlayerController.Platforms == PlatformSwitch.Android)
            {
                _currentInteraction.gameObject.layer = default;
                _currentInteraction.OnInteractable();
            }
        }
    }
}
