using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponShooter : MonoBehaviour
{
    public Transform firePoint;
    public AudioClip shootSound;
    public InputActionProperty triggerAction;
    public float range = 50f;

    void Update()
    {
        if (triggerAction.action.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, firePoint.position);
        }

        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            TargetHit target = hit.collider.GetComponent<TargetHit>();

            if (target != null)
            {
                target.Hit();
            }

            StartGame startGame = hit.collider.GetComponent<StartGame>();

            if (startGame != null)
            {
                startGame.Hit();
            }
        }
    }
}
