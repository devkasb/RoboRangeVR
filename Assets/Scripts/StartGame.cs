using UnityEditor.Build.Content;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameManager gameManager;
    public void Hit()
    {
        if (gameManager != null)
        {
            gameManager.StartGame();
        }

        Debug.Log("Game Started");
    }
}
