using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3; 
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
    public ScoreManager scoreManager;

    void Start()
    {
        UpdateLivesText();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesText();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateLivesText()
    {
        if(livesText != null)
        {
            livesText.text = "Balls: " + lives.ToString();
        }
    }

    void GameOver()
    {
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
