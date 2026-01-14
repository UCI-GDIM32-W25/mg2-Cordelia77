using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 2f;

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            float randomY = Random.Range(-3f, 3f);
            Vector2 spawnPosition = new Vector2(10f, randomY);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}