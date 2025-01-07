using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private Camera _playerCamera;
    private InteractableAbstract _currentInteraction;

    private void Start()
    {
        _playerCamera = GetComponentInChildren<Camera>();
    }

    public void HandleInteractionCheck(Vector3 interactionRayPoint, float interactionDistance)
    {
        Debug.DrawRay(_playerCamera.transform.position, interactionRayPoint * interactionDistance, Color.red);

        if (Physics.Raycast(_playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance) && hit.collider.gameObject.layer == 10)
        {
            if (hit.collider.gameObject.layer == 10 && (_currentInteraction == null || hit.collider.gameObject.GetInstanceID() != _currentInteraction.GetInstanceID()))
            {
                hit.collider.TryGetComponent(out _currentInteraction);

                if(_currentInteraction)
                {
                    _currentInteraction.OnFocus();
                }
            }
        }
        else if (_currentInteraction)
        {
            _currentInteraction.OnLoseFocus();
            _currentInteraction = null;
        }
    }

    public void HandleInteractionInput(KeyCode interactionKey, Vector3 interactionRayPoint, float interactionDistance, LayerMask interactionLayer)
    {
        if (Input.GetKeyDown(interactionKey) && _currentInteraction != null && Physics.Raycast(_playerCamera.ViewportPointToRay(interactionRayPoint), interactionDistance, interactionLayer))
        {
            if (_currentInteraction.PlayerController.Platforms == PlatformSwitch.PC)
            {
                _currentInteraction.OnInteractable();
            }
        }
    }
}
