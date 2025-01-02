using UnityEngine;

public class BobbingAndSwayHand : MonoBehaviour
{
    [Header("Sway")]
    public float step = 0.01f;
    public float maxStepDistance = 0.06f;
    public float rotationStep = 4f;
    public float maxRotationStep = 5f;
    public float smooth = 10f;

    private float smoothRot = 12f;

    private Vector3 swayPos;
    private Vector3 swayEulerRot;

    void Update()
    {
        GetInput();

        Sway();
        SwayRotation();

        CompositePositionRotation();
    }
    Vector2 lookInput;

    void GetInput()
    {
        lookInput.x = Input.GetAxis("Mouse X");
        lookInput.y = Input.GetAxis("Mouse Y");
    }


    void Sway()
    {
        Vector3 invertLook = lookInput * -step;
        invertLook.x = Mathf.Clamp(invertLook.x, -maxStepDistance, maxStepDistance);
        invertLook.y = Mathf.Clamp(invertLook.y, -maxStepDistance, maxStepDistance);

        swayPos = invertLook;
    }

    void SwayRotation()
    {
        Vector2 invertLook = lookInput * -rotationStep;
        invertLook.x = Mathf.Clamp(invertLook.x, -maxRotationStep, maxRotationStep);
        invertLook.y = Mathf.Clamp(invertLook.y, -maxRotationStep, maxRotationStep);
        swayEulerRot = new Vector3(invertLook.y, invertLook.x, invertLook.x);
    }

    void CompositePositionRotation()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, swayPos, Time.deltaTime * smooth);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(swayEulerRot), Time.deltaTime * smoothRot);
    }
}
