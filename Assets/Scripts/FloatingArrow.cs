using UnityEngine;

public class FloatingArrow : MonoBehaviour
{
    private Vector3 startp;

    void Start()
    {
        startp = transform.position;
    }

    void Update()
    {
        transform.position = startp + Vector3.up * Mathf.Sin(Time.time * 2f) * 0.05f;
    }
}
