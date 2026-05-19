using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRControllerShooter : MonoBehaviour
{
    public AudioClip shootSound;
    public InputActionProperty triggerAction;
    void Update()
    {
        if (triggerAction.action.WasPressedThisFrame())
        {
            if (shootSound != null)
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
            }
            
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);

                StartGame startGame = hit.collider.GetComponent<StartGame>();

                if (startGame != null)
                {
                    startGame.Hit();
                }

                TargetHit target = hit.collider.GetComponent<TargetHit>();

                if (target != null)
                {
                    target.Hit();
                }
            }

        }
    }
}
