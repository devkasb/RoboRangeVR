using UnityEngine;
using UnityEngine.InputSystem;

public class DebugShooter : MonoBehaviour
{
    public AudioClip shootSound;
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (shootSound != null)
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Getroffen: " + hit.collider.gameObject.name);
                
                TargetHit target = hit.collider.GetComponent<TargetHit>();

                if (target != null)
                {
                    target.Hit();
                }
            }
        }
    }
}
