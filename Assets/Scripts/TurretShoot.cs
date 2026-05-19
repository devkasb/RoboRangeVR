using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float shootInterval = 2f;

    public void StartShooting()
    {
        InvokeRepeating(nameof(ShootProjectile), 1f, shootInterval);
    }

    void ShootProjectile()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            return;
        }

        // aktuelle player position
        Vector3 playerPosition = Camera.main.transform.position;

        // calculate direction
        Vector3 direction = (playerPosition - firePoint.position).normalized;

        // spawn projectile prefab
        GameObject projectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        TurretProjectile projec = projectile.GetComponent<TurretProjectile>();

        if (projec != null)
        {
            projec.direction = direction;
        }
    }
}
