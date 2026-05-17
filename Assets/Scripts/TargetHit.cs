using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public void Hit()
    {
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

        if (scoreManager != null)
        {
            scoreManager.AddScore(1);
        }

        Destroy(gameObject);
    }
}
