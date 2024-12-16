using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public CharacterController PlayerCharacterController;
    private Camera playerCamera;

    private float rotationX;

    public bool DurringCrouchAnimation;
    public bool isCrouching = false;

    private void Awake()
    {
        PlayerCharacterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Move(Vector3 direction, float gravity, bool canMove)
    {
        if (!PlayerCharacterController.isGrounded) { direction.y -= gravity; }

        if (canMove)
            PlayerCharacterController.Move(direction * Time.deltaTime);
    }

    public void CameraInput( float lookSpeedY, float lookSpeedX, int lookXLimit)
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeedX;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedY, 0);
    }

    public IEnumerator CrouchStand(
        float standingHeight, float crouchingHeight, float timeToCrouch,
        Vector3 standingCenter, Vector3 crouchingCenter)
    {
        if (isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f))
        {
            yield break;
        }

        DurringCrouchAnimation = true;

        float timeElapse = 0f;

        float targetHeight = isCrouching ? standingHeight : crouchingHeight;
        float currentHeight = PlayerCharacterController.height;

        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = PlayerCharacterController.center;

        while (timeElapse < timeToCrouch)
        {
            PlayerCharacterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapse/timeToCrouch);
            PlayerCharacterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapse/timeToCrouch);

            timeElapse += Time.deltaTime;

            yield return null;
        }

        PlayerCharacterController.height = targetHeight;
        PlayerCharacterController.center = targetCenter;

        isCrouching = !isCrouching;

        DurringCrouchAnimation = false;

    }
}
