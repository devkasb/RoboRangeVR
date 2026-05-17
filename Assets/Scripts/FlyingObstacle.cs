using UnityEngine;

public class ObsticalFlying : MonoBehaviour
{
    public float speed;
    public float height;

    private Vector3 startp;

    void Start()
    {
        startp = transform.position;
        speed = 1.5f;
        height = 1f;
    }

    void Update()
    {
        float newY = startp.y + Mathf.Sin(Time.time * speed) * height;

        transform.position = new Vector3 (
            startp.x,
            newY,
            startp.z
        );
    }
}

