using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TargetSpawner targetSpawner;
    public TurretShoot[] turrets;

    public float turretShootInterval = 2f;
    private bool gameStarted = false;

    public void StartGame()
    {
        if (gameStarted)
        {
            return;
        }

        gameStarted = true;

        if (targetSpawner != null)
        {
            targetSpawner.StartSpawning();
        }

        InvokeRepeating(nameof(ShootRandomTurret), 1f, turretShootInterval);

        Debug.Log("Game started");
    }

    void ShootRandomTurret()
    {
        if (turrets.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, turrets.Length);
        turrets[randomIndex].ShootProjectile();
    }
}
