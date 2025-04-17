using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // si tu utilises TextMeshPro, sinon remplace par UnityEngine.UI et Text

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI")]
    public TMP_Text scoreText;      // ou Text scoreText si t'utilises l'ancien UI
    public GameObject gameOverPanel;

    int score = 0;

    void Awake()
    {
        // singleton basique
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        Time.timeScale = 1f; // on s’assure que le temps est normal au démarrage
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    // ces deux méthodes servent pour tes boutons UI
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
