using UnityEngine;
using UnityEngine.InputSystem;

public class TPSLookController : MonoBehaviour
{
    public Transform cameraRoot;

    public float mouseSensitivity = 1.5f;
    public float minPitch = -40f;
    public float maxPitch = 70f;

    [Header("Input")]
    public InputActionReference look;

    float yaw;
    float pitch;

    void OnEnable()
    {
        look.action.Enable();
    }

    void OnDisable()
    {
        look.action.Disable();
    }

    void Update()
    {
        Vector2 delta = look.action.ReadValue<Vector2>();

        yaw += delta.x * mouseSensitivity;
        pitch -= delta.y * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
        cameraRoot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
