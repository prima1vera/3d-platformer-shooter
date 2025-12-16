using UnityEngine;

public class FreeAimCamera : MonoBehaviour
{
    public Transform aimTarget;
    public float aimDistance = 50f;
    public float sensitivity = 0.5f;

    Vector2 screenAim = new Vector2(0.5f, 0.5f);

    void Update()
    {
        // ----- SAFE AIM MOVEMENT -----
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        screenAim.x += mx * sensitivity * 0.01f;
        screenAim.y += my * sensitivity * 0.01f;

        // clamp to safe zone
        screenAim.x = Mathf.Clamp(screenAim.x, 0.3f, 0.7f);
        screenAim.y = Mathf.Clamp(screenAim.y, 0.3f, 0.7f);

        // ----- RAY TO WORLD -----
        Ray ray = Camera.main.ViewportPointToRay(screenAim);

        if (Physics.Raycast(ray, out RaycastHit hit, aimDistance))
        {
            aimTarget.position = Vector3.Lerp(aimTarget.position, hit.point, 0.15f);
        }
        else
        {
            Vector3 farPoint = ray.GetPoint(aimDistance);
            aimTarget.position = Vector3.Lerp(aimTarget.position, farPoint, 0.15f);
        }
    }
}
