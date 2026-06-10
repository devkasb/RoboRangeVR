using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponShooter2 : MonoBehaviour
{
    public Transform firePoint;
    public AudioClip shootSound;

    public LineRenderer shotLine;
    public float lineVisibleTime = 0.05f;

    public float range = 50f;

    public InputActionReference triggerAction;

    void OnEnable()
    {
        if (triggerAction != null)
        {
            triggerAction.action.Enable();
        }
    }

    void Update()
    {
        if (triggerAction != null &&
            triggerAction.action.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(
                shootSound,
                firePoint.position
            );
        }

        RaycastHit hit;

        Vector3 start = firePoint.position;
        Vector3 end = start + firePoint.forward * range;

        if (Physics.Raycast(
                firePoint.position,
                firePoint.forward,
                out hit,
                range))
        {
            end = hit.point;

            TargetHit target =
                hit.collider.GetComponent<TargetHit>();

            if (target != null)
            {
                target.Hit();
            }

            StartGame startGame =
                hit.collider.GetComponent<StartGame>();

            if (startGame != null)
            {
                startGame.Hit();
            }

            ResetGame resetGame =
                hit.collider.GetComponent<ResetGame>();

            if (resetGame != null)
            {
                resetGame.Hit();
            }
        }

        if (shotLine != null)
        {
            shotLine.SetPosition(0, start);
            shotLine.SetPosition(1, end);

            StopAllCoroutines();
            StartCoroutine(ShowShotLine());
        }
    }

    IEnumerator ShowShotLine()
    {
        shotLine.enabled = true;

        yield return new WaitForSeconds(
            lineVisibleTime
        );

        shotLine.enabled = false;
    }
}