using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text totalCoinsText;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject gameMechanics;
    [SerializeField] private GameObject startGameCanvas;
    [SerializeField] private Text charactersScore;
    [SerializeField] private Text charactersCoins;
    [SerializeField] private Text startGameScore;

    private StartGameTap startGameTap;
    private PlatformPlacer platformPlacer;
    private int coins = 0;
    private Color[] timeOfDay = new Color[4] {new Color(1.0f, 0.86f, 0.94f, 1f),
                                              new Color(0.95f, 0.94f, 0.87f, 1f),
                                              new Color(1f, 0.67f, 0.1f, 1f),
                                              new Color(0.04f, 0.06f, 0.21f, 1f)};
    private int timeCounter = 0;
    private Camera cameraComponent;
    private int currentTimeOfDay;
    public static Text activeFloatText;
    public int score = 0;
    private static int bestScore;
    private static int totalCoins;
    private static int currentScore;
    private bool _isDayChanged = true;

    void Start()
    {       
        if (currentScore != 0)
        {
            startGameCanvas.SetActive(false);
            startGameTap = FindObjectOfType<StartGameTap>();
            startGameTap.FirstTouch();
            
        }
        cameraComponent = mainCamera.GetComponent<Camera>();
        platformPlacer = mainCamera.GetComponent<PlatformPlacer>();
        UpdateGameCoins();
        UpdateScore();

        cameraComponent.backgroundColor = timeOfDay[timeCounter];
    }

    private void FixedUpdate()
    {
        if (score % 20 == 0 && score != 0 && _isDayChanged)
        {
            _isDayChanged = false;
            platformPlacer.currentCatIndex = 6;
            SetTimeOfDay();
        }
        else if (score % 5 != 0)
        {
            _isDayChanged = true;
        }
    }

    public void IncreaseCoinScore(int point)
    {
        coins += point;
        totalCoins += point;

        UpdateGameCoins();

        SaveGame();
    }

    public void IncreaseScore(int point)
    {
        score += point;
        if (score > bestScore)
        {
            bestScore = score;
        }
        UpdateScore();

        if (score >= 1 && gameMechanics != null)
        {
            gameMechanics.SetActive(false);
            currentScore = score;
        }

        SaveGame();
    }

    private void UpdateGameCoins()
    {
        coinsText.text = $"{coins}";
        totalCoinsText.text = $"TOTAL {totalCoins}";
        charactersCoins.text = $"{coins}";
    }

    private void UpdateScore()
    {
        scoreText.text = $"{score}";
        bestScoreText.text = $"BEST {bestScore}";
        startGameScore.text = $"BEST {bestScore}";
        charactersScore.text = $"BEST {bestScore}";
    }

    public void SetTimeOfDay()
    {
        timeCounter++;

        if (timeCounter > 3)
        {
            timeCounter = 0;
        }
        cameraComponent.backgroundColor = timeOfDay[timeCounter];
        currentTimeOfDay = timeCounter;
    }

    private void SaveGame()
    {
        PlayerPrefs.SetInt("bestScore", bestScore);
        PlayerPrefs.SetInt("totalCoins", totalCoins);
        PlayerPrefs.Save();
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("bestScore"))
        {
            bestScore = PlayerPrefs.GetInt("bestScore");
            totalCoins = PlayerPrefs.GetInt("totalCoins");
        }
        UpdateScore();
        UpdateGameCoins();
    }
}
