using UnityEngine;

public class HideWeaponIndicator : MonoBehaviour
{
    public GameObject indicator;
    public float moveDistance = 0.05f;

    private Vector3 startp;
    private bool indicatorHidden = false;

    void Start()
    {
        startp = transform.position;
    }

    void Update()
    {
        if (indicatorHidden || indicator == null)
        {
            return;
        }

        float distance = Vector3.Distance(
            startp,
            transform.position
        );

        if (distance > moveDistance)
        {
            indicator.SetActive(false);
            indicatorHidden = true;
        }
    }
}
