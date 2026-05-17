using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreValueText;
    private int score = 0;

    public void AddScore(int points)
    {
        score += points;
        scoreValueText.text = score.ToString();
    }

    void Start()
    {
        AddScore(0);
    }
}
