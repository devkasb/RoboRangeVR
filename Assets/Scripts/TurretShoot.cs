using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public Vector3 playerPosition;

    void Start()
    {
        playerPosition = Camera.main.transform.position;
    }
    
    void shootProjectile()
    {
        if (playerPosition != null)
        {
            GetComponent<TurretProjectile>();
        }
    }
}
