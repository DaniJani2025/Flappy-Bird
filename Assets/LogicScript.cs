using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public bool gameStarted = false;
    public int playerScore;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI topScoreText;
    public TextMeshProUGUI yourScoreText;
    public GameObject gameOverScreen;
    public TitleManagerScript titleManager;
    public GameObject exitButton;
    private int topScore;


    void Start()
    {
        topScore = PlayerPrefs.GetInt("TopScore", 0);
        topScoreText.text = $"Top Score: {topScore}";

#if UNITY_WEBGL
        if (exitButton != null)
            exitButton.SetActive(false);
#endif
    }

    public void StartGame()
    {
        if (gameStarted) return;

        gameStarted = true;
        titleManager.StartGameUI();
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        currentScoreText.text = playerScore.ToString();
        topScore = PlayerPrefs.GetInt("TopScore", 0);
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        Time.timeScale = 0f;
        yourScoreText.text = "Your Score: " + playerScore.ToString();
        if (playerScore > topScore)
        {
            topScore = playerScore;
            PlayerPrefs.SetInt("TopScore", topScore);
            PlayerPrefs.Save();
        }

        topScoreText.text = $"Top Score: {topScore}";
        gameOverScreen.SetActive(true);
    }

    void Awake()
    {
        Time.timeScale = 0f;
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
