using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 2f;

    public float spawnX = 15f;
    public float coinHeight = 1.5f;

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        SpawnCoin();
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            SpawnCoin();
        }
    }
    void SpawnCoin()
    {
        Vector2 spawnPosition = new Vector2(spawnX, coinHeight);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}