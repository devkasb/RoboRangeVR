using UnityEngine;

public class SphereMove : MonoBehaviour
{
    // set speed
    public float speed = 1f;

    // set move left
    public float left = 2f;

    // set startpostion sphere
    public Vector3 startp;

    void Start()
    {
        startp = transform.position;
    }

    void Update()
    {
        float newX = startp.x - Mathf.Sin(Time.time * speed) * left;

        transform.position = new Vector3 (
            newX,
            startp.y,
            startp.z
        );
    }
}
