using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5f;
    public float lifeTime = 30f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    
    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
