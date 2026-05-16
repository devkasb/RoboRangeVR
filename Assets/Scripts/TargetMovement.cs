using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float destroyXLimit = 15f;

    void Start()
    {
        speed = Random.Range(2f, 6f);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > destroyXLimit)
        {
            Destroy(gameObject);
        }
    }
}
