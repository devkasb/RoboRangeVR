using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public GameObject hitEffectPrefab;
    public AudioClip hitSound;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    public void Hit()
    {
        // Effect
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }

        // Sound
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        // Score
        if (scoreManager != null)
        {
            scoreManager.AddScore(1);
        }

        Destroy(gameObject);
    }
}
