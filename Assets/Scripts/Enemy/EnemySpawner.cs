using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefabShoot;
    public float spawnInterval = 1f;
    public float spawnIntervalS = 3f;
    public float minSpawnDistance = 10f;
    public float maxSpawnDistance = 20f;
    public float decreaseFactor = 0.05f; // the factor by which the spawn interval decreases after each spawn

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnEnemiesShoot());
    }

   IEnumerator SpawnEnemies()
{
    while (true)
    {
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * Random.Range(minSpawnDistance, maxSpawnDistance);
        Instantiate(enemyPrefab, (Vector2)transform.position + spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(spawnInterval);
        spawnInterval *= 0.98f; // decrease spawnInterval by 5% each time
        spawnInterval = Mathf.Max(0.4f, spawnInterval); // ensure the interval doesn't go below 0.1 seconds
    }
}

IEnumerator SpawnEnemiesShoot()
{
    while (true)
    {
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * Random.Range(minSpawnDistance, maxSpawnDistance);
        Instantiate(enemyPrefabShoot, (Vector2)transform.position + spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(spawnIntervalS);
        spawnIntervalS *= 0.98f; // decrease spawnIntervalS by 5% each time
        spawnIntervalS = Mathf.Max(1f, spawnIntervalS); // ensure the interval doesn't go below 0.1 seconds
    }
}
}