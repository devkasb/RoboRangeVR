using UnityEngine;
using TMPro;
using Unity.Burst.CompilerServices;

public class GameManager : MonoBehaviour
{
    public TargetSpawner targetSpawner;
    public TurretShoot[] turrets;
    public Transform activeProjectileParent;

    public GameObject gameOverText;
    public GameObject resetButton;

    public TMP_Text timer;

    public float turretShootInterval = 2f;
    public float gameDuration = 60f;

    private float remainingTime;
    private bool gameStarted = false;


    void Update()
    {
        if (!gameStarted)
        {
            return;
        }

        remainingTime -= Time.deltaTime;

        UpdateTimerText();

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;

            UpdateTimerText();

            Debug.Log("Times over");

            EndRound();
        }
    }

    public void StartGame()
    {
        if (gameStarted)
        {
            return;
        }

        gameStarted = true;
        remainingTime = gameDuration;

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

       if (resetButton != null)
        {
            resetButton.SetActive(false);
        }

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
        Debug.Log("GameOver");

        EndRound();

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
    }

    void EndRound()
    {
        gameStarted = false;

        CancelInvoke(nameof(ShootRandomTurret));

        if (activeProjectileParent != null)
        {
            foreach (Transform projectile in activeProjectileParent)
            {
                Destroy(projectile.gameObject);
            }
        }

        if (targetSpawner != null)
        {
            targetSpawner.StopSpawning();
        }

        if (resetButton != null)
        {
            resetButton.SetActive(true);
        }
    }


    void UpdateTimerText()
    {
        if (timer == null)
        {
            return;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);

        int seconds = Mathf.FloorToInt(remainingTime % 60); 

        timer.text = $"{minutes:00}:{seconds:00}"; 
    }
}
