using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform activeProjectileParent;

    public void ShootProjectile()
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
            Quaternion.identity,
            activeProjectileParent
        );

        TurretProjectile p = projectile.GetComponent<TurretProjectile>();

        if (p != null)
        {
            p.direction = direction;
        }
    }
}
