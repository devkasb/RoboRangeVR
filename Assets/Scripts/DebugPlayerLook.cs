using UnityEngine;
using UnityEngine.InputSystem;

public class DebugPlayerLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 1.5f;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity;
        float mouseY = mouseDelta.y * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(
            xRotation,
            0f,
            0f
        );

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
