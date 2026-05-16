using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float randomSpeed;
    public Vector3 direction;
    public float destroyXLimit = 15f;

    void Start()
    {
        randomSpeed = Random.Range(2f, 6f);
    }

    void Update()
    {
        transform.position += direction * randomSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > destroyXLimit)
        {
            Destroy(gameObject);
        }
    }
}
