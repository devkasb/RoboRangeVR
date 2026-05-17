using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public AudioClip hitSound;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    public void Hit()
    {
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        if (scoreManager != null)
        {
            scoreManager.AddScore(1);
        }

        Destroy(gameObject);
    }
}
