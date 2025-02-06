using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public bool DurringCrouchAnimation;
    public bool isCrouching = false;

    private bool _isStairsZone;

    private Camera _playerCamera;
    private CharacterController _playerCharacterController;

    [HideInInspector]public Vector2 _lookAxis;
    private float mouseRotationX;

    private float rotationX;
    private float _defaulthYPos = 0f;
    private float _timer;

    public CharacterController PlayerCharacterController => _playerCharacterController;
    public Camera PlayerCamera => _playerCamera;

    private void Start()
    {
        _playerCharacterController = GetComponent<CharacterController>();
        _playerCamera = GetComponentInChildren<Camera>();
    }

    public void Move(Vector3 direction, float gravity, float ladderSpeed, LadderTrigger ladderTrigger, PlayerController PlayerPreferences, PlayerInput PlayerInput)
    {
        if (!PlayerInput.isCrouch) { LadderHandler(ladderSpeed, ladderTrigger, PlayerPreferences, PlayerInput); }
        else { direction.y += gravity * Time.deltaTime; }

        if (!_playerCharacterController.isGrounded && ladderTrigger.IsClimb == false) { direction.y += gravity * Time.deltaTime; }

        SwitchSlopeValue();

        _playerCharacterController.Move(direction);
    }

    private void LadderHandler(float ladderSpeed, LadderTrigger ladderTrigger, PlayerController PlayerPreferences, PlayerInput PlayerInput)
    {
        if (ladderTrigger.IsClimb == true)
        {

            float ladderDirection = 0;

            if (PlayerPreferences.Platforms == PlatformSwitch.PC)
            {
                ladderDirection = Input.GetAxis("Vertical");
            }
            else if (PlayerPreferences.Platforms == PlatformSwitch.Android)
            {
                ladderDirection = PlayerInput.PlayerJoystick.Vertical;
            }

            Vector3 ladder = new Vector3(0, ladderDirection * ladderSpeed, 0);

            _playerCharacterController.Move(ladder * Time.deltaTime);
        }
    }

    public void CameraInputPC( float lookSpeedY, float lookSpeedX, int lookXLimit)
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeedX;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        _playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        _playerCharacterController.transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedY, 0);
    }
    public void CameraInputAndroid(float lookSpeedY, float lookSpeedX, int lookXLimit)
    {
        float MoveX = _lookAxis.x;
        float MoveY = _lookAxis.y;

        mouseRotationX -= MoveY * lookSpeedX;
        mouseRotationX = Mathf.Clamp(mouseRotationX, -lookXLimit, lookXLimit);

        _playerCamera.transform.localRotation = Quaternion.Euler(mouseRotationX, 0, 0);
        _playerCharacterController.transform.rotation *= Quaternion.Euler(0, MoveX * lookSpeedY, 0);
    }

    public IEnumerator CrouchStand(
        float standingHeight, float crouchingHeight, float timeToCrouch,
        Vector3 standingCenter, Vector3 crouchingCenter)
    {

        if (isCrouching && Physics.Raycast(_playerCamera.transform.position, Vector3.up, 4f)) {
            yield break;
        }

        DurringCrouchAnimation = true;

        float timeElapse = 0f;

        float targetHeight = isCrouching ? standingHeight : crouchingHeight;
        float currentHeight = _playerCharacterController.height;

        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = _playerCharacterController.center;

        while (timeElapse < timeToCrouch)
        {
            _playerCharacterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapse/timeToCrouch);
            _playerCharacterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapse/timeToCrouch);

            timeElapse += Time.deltaTime;

            yield return null;
        }

        _playerCharacterController.height = targetHeight;
        _playerCharacterController.center = targetCenter;

        isCrouching = !isCrouching;

        DurringCrouchAnimation = false;

    }

    public void HandlHeadBobbing(Vector3 direction, bool isRunning,
        float crouchSpeed, float runSpeed, float walkSpeed, float idleSpeed,
        float crouchAmount, float runAmount, float walkAmount, float idleAmount)
    {
        if (Mathf.Abs(direction.x) > 0.001f || Mathf.Abs(direction.z) > 0.001f)
        {
            _timer += Time.deltaTime * (isCrouching ? crouchSpeed : isRunning ? runSpeed : walkSpeed);
            _playerCamera.transform.localPosition = new Vector3(
                _defaulthYPos + Mathf.Cos(_timer / 2) * ((isCrouching ? crouchAmount : isRunning ? runAmount : walkAmount) / 2),
                _defaulthYPos + Mathf.Sin(_timer) * (isCrouching ? crouchAmount : isRunning ? runAmount : walkAmount),
                _playerCamera.transform.localPosition.z);
        }
        else
        {
            _timer += Time.deltaTime * idleSpeed;
            _playerCamera.transform.localPosition = new Vector3(
                _playerCamera.transform.localPosition.x,
                _defaulthYPos + Mathf.Sin(_timer) * idleAmount,
                _playerCamera.transform.localPosition.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StairsZone") { _isStairsZone = true; }
        if (other.gameObject.tag == "ExitStairsZone") { _isStairsZone = false; }
    }

    private void SwitchSlopeValue()
    {
        if (_isStairsZone) { _playerCharacterController.slopeLimit = 180f; }
        else { _playerCharacterController.slopeLimit = 60f; }
    }
}
