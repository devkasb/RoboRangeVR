using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public GameManager gameManager;
    public AudioClip damageSound;
    public Transform healthFill;
    private Vector3 initialScale;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthFill != null)
        {
            initialScale = healthFill.localScale;
        }

        UpdateHealthDisplay();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (damageSound != null)
        {
            AudioSource.PlayClipAtPoint(
                damageSound,
                transform.position
            );
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Calling GameOver");

            if (gameManager != null)
            {
                gameManager.GameOver();
            } else
            {
                Debug.Log("GameManager missing in PlayerHealth");
            }
        }


        UpdateHealthDisplay();

        Debug.Log("Health: " + currentHealth);
    }

    void UpdateHealthDisplay()
    {
        if (healthFill == null)
        {
            return;
        }

        float healthPercent = (float)currentHealth / maxHealth;
        healthPercent = Mathf.Clamp01(healthPercent);

        if (healthPercent <= 0f)
        {
            healthFill.gameObject.SetActive(false);
            return;
        }

        healthFill.localScale = new Vector3(
            initialScale.x,
            initialScale.y * healthPercent,
            initialScale.z
        );
    }
}
