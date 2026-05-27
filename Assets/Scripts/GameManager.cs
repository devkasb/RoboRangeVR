using UnityEditor.Animations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TargetSpawner targetSpawner;
    public TurretShoot[] turrets;
    public Transform activeProjectileParent;

    public GameObject gameOverText;

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

    public void GameOver()
    {
        Debug.Log("GameOver reached");

        CancelInvoke(nameof(ShootRandomTurret));

        foreach (Transform child in activeProjectileParent)
        {
            Destroy(child.gameObject);
        }

        if (targetSpawner != null)
        {
            targetSpawner.StopSpawning();
        }
        else
        {
            Debug.Log("TargetSpawner missing in GameManager");
        }

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
    }
}
