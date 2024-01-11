using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text scoreText;
    [SerializeField] private GameObject menuGameOver;

    private int score = 0;
    public Color[] colors { get; private set; }

    public bool gameOver { get; private set; } = false;
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;

        colors = new Color[] { Random.ColorHSV(), Random.ColorHSV(), Random.ColorHSV(),
                Random.ColorHSV(), Random.ColorHSV(), Random.ColorHSV(),
                Random.ColorHSV(), Random.ColorHSV(), Random.ColorHSV(),
                Random.ColorHSV() };
    }

    void Start()
    {
        Refresh();
    }

    public void AddScore(int value)
    {
        score += value;
        Refresh();
    }

    private void Refresh()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void GameOver()
    {
        gameOver = true;
        menuGameOver.SetActive(true);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
