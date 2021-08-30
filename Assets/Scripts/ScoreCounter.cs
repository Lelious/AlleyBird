using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Platform platformScript;
    private GameObject gameStatsObject;
    private GameStats gameStats;
    private bool _isPlaced;
    private const int score = 1;
    private int scoreCounter;
    private Text platformProgressText;

    private void Awake()
    {
        gameStatsObject = GameObject.Find("GameStats");
        gameStats = gameStatsObject.GetComponent<GameStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (collision.gameObject.name.Equals("Bird") && !_isPlaced && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {           
            gameStats.IncreaseScore(score);
            scoreCounter = gameStats.score;
            _isPlaced = true;
        }
    }
}
