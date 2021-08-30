using System.Collections.Generic;
using UnityEngine;

public class PlatformPlacer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private Platform _firstPlatform;
    [SerializeField] private Platform _secondPlatform;
    [SerializeField] private Platform _thirdPlatform;
    [SerializeField] private GameObject[] _coin;
    [SerializeField] private GameObject[] _cat;
    [Range(0, 100)]
    [SerializeField] private int _catSpawnChance;
    [Range(0, 100)]
    [SerializeField] private int _coinSpawnChance;


    public int currentCatIndex = 3;

    private List<Platform> spawnedPlatforms = new List<Platform>();
    private float spawnOffset = 2.35f;
    private float playerViewOffset = 15;
    private int currentCoinIndex;    
    private float coinPosX;
    private float coinPosY;
    void Start()
    {
        spawnedPlatforms.Add(_firstPlatform);
        spawnedPlatforms.Add(_secondPlatform);
        spawnedPlatforms.Add(_thirdPlatform);
    }

    void Update()
    {
        if (_player.position.y > spawnedPlatforms[spawnedPlatforms.Count - 1].platformTransform.position.y - playerViewOffset)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        Platform newPlatform = Instantiate(_platformPrefab);
        newPlatform.transform.position = spawnedPlatforms[spawnedPlatforms.Count - 1].platformTransform.position + new Vector3(0, spawnOffset, 0);

        spawnedPlatforms.Add(newPlatform);

        if (spawnedPlatforms.Count > 10)
        {
            Destroy(spawnedPlatforms[0].gameObject);
            spawnedPlatforms.RemoveAt(0);
        }

        SpawnCoin(Random.Range(0, 101));
        SpawnCat(Random.Range(0, 101), Random.Range(0, currentCatIndex));
    }

    private void SpawnCoin(int chance)
    {
        if (chance <= _coinSpawnChance)
        {
            coinPosX = Random.Range(-1.5f, 2.0f);
            coinPosY = Random.Range(-0.2f, 1.0f);
            Platform lastSpawnedPlatform = spawnedPlatforms[spawnedPlatforms.Count - 1];
            GameObject newCoin = Instantiate(_coin[currentCoinIndex], lastSpawnedPlatform.transform);
            newCoin.transform.position += new Vector3(coinPosX, coinPosY, 0);
        }
    }

    private void SpawnCat(int chance, int catType)
    {
        if (chance <= _catSpawnChance)
        {
            coinPosX = Random.Range(-1.5f, 2.0f);
            coinPosY = 0.0f;
            Platform lastSpawnedPlatform = spawnedPlatforms[spawnedPlatforms.Count - 1];
            if (catType == 5)
            {
                lastSpawnedPlatform.runningCatSpawner.SetActive(true);
            }
            else
            {
                GameObject newCat = Instantiate(_cat[catType], lastSpawnedPlatform.transform);
                newCat.transform.position += new Vector3(coinPosX, coinPosY, 0);
            }
        }
    }
}
