using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coinValue;

    private GameObject gameStatsObject;
    private GameStats gameStats;

    private void Awake()
    {
        gameStatsObject = GameObject.Find("GameStats");
        gameStats = gameStatsObject.GetComponent<GameStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Bird"))
        {
            gameStats.IncreaseCoinScore(coinValue);
            Destroy(gameObject);
        }

        if (collision.gameObject.name.Contains("Cat"))
        {
            Destroy(gameObject);
        }
    }
}
