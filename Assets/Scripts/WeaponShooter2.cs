using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WeaponShooter2 : MonoBehaviour
{
    public Transform firePoint;
    public AudioClip shootSound;

    public LineRenderer shotLine;
    public float lineVisibleTime = 0.05f;

    public float range = 50f;

    public InputActionReference triggerAction;

    public HapticImpulsePlayer hapticImpulsePlayer;
    public float hapticIntensity = 0.5f;
    public float hapticDuration = 0.1f;

    private XRGrabInteractable grabInteractable;
    private bool isHeld = false;

    void Awake()
    {
        grabInteractable = GetComponentInChildren<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(_ => isHeld = true);
            grabInteractable.selectEntered.AddListener(_ => isHeld = false);
        }
    }


    void OnEnable()
    {
        if (triggerAction != null)
        {
            triggerAction.action.Enable();
        }
    }

    void Update()
    {
        if (!isHeld)
        {
            return;
        }

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

        if (hapticImpulsePlayer != null)
        {
            hapticImpulsePlayer.SendHapticImpulse(
                hapticIntensity,
                hapticDuration
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

            PlayMusic music = hit.collider.GetComponent<PlayMusic>();

            if (music != null)
            {
                music.Hit();
            }

            ExitGame exit = hit.collider.GetComponent<ExitGame>();

            if (exit != null)
            {
                exit.Hit();
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

        yield return new WaitForSeconds(lineVisibleTime);

        shotLine.enabled = false;
    }
}