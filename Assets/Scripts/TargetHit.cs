using UnityEngine;

public class TargetHit : MonoBehaviour
{

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    public void Hit()
    {
        if (scoreManager != null)
        {
            scoreManager.AddScore(1);
        }

        Destroy(gameObject);
    }
}
