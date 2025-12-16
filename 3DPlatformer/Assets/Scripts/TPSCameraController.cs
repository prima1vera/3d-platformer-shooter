using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    public float sensitivity = 200f;
    public Transform target;  // Player

    float yaw;
    float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // берём начальные углы
        Vector3 angles = transform.rotation.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -40f, 70f);  // ограничение вверх/вниз

        // вращаем камеру вокруг персонажа
        transform.position = target.position;
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
