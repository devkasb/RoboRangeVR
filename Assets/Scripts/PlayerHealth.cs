using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
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

        if (currentHealth < 0)
        {
            currentHealth = 0;
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

        healthFill.localScale = new Vector3(
            initialScale.x,
            initialScale.y * healthPercent,
            initialScale.z
        );
    }
}
