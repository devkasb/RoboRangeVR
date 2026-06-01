using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform playerCamera;

    void Update()
    {
        bool vrActive = XRSettings.isDeviceActive;
        
        if (!vrActive)
        {
            // wasd movement
            Vector2 moveInput = Vector2.zero;

            if (Keyboard.current.wKey.isPressed)
            {
                moveInput.y += 1;
            }

            if (Keyboard.current.sKey.isPressed)
            {
                moveInput.y -= 1;
            }

            if (Keyboard.current.dKey.isPressed)
            {
                moveInput.x += 1;
            }

            if (Keyboard.current.aKey.isPressed)
            {
                moveInput.x -= 1;
            }

            Vector3 forward = playerCamera.forward;
            Vector3 right = playerCamera.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            Vector3 movement = forward * moveInput.y + right * moveInput.x;

            transform.position += movement * moveSpeed * Time.deltaTime;
        }
        else
        {
            // VR movement
        }
    }
}
