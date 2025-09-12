using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel; // Panel ที่มีข้อความ Game Over

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
}
