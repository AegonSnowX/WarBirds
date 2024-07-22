using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] float xPos = 10;
    [SerializeField] float maxY = 10;
    [SerializeField] float minY = 5;
    [SerializeField] int intervalTime = 3;

    private bool alreadySpawned;

    private int waveCount;
    static private int _score;

    [SerializeField] List<GameObject> enemyPrefabs;

    private void Awake()
    {
        InvokeRepeating("SpawnEnemies", 1, intervalTime);
        waveCount = 0;
        _score = 0;
    }

    private void Update()
    {

    }

    void WaveCountUp()
    {
        waveCount++;
    }

    void SpawnEnemies()
    {
        if (IsEnemyRemaining())
        {
            float RandomXSpawnPosition = Random.Range(0f, 2f) == 0 ? xPos : -xPos;
            float RandomYSpawnPosition = Random.Range(minY, maxY + 1);
            int numbersToSpawn = CalculateSpawning();

            for (int i = 0; i < numbersToSpawn; i++)
            {
                GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
                Instantiate(randomPrefab, new Vector2(RandomXSpawnPosition, RandomYSpawnPosition), randomPrefab.transform.rotation);
            }
            alreadySpawned = true;
        }
        
    }

    int CalculateSpawning()
    {
        int EnemyspawnCountPerWave = 1;
        for (int i = 0; i < waveCount; i++)
        {
            EnemyspawnCountPerWave *= 2;
        }
        return EnemyspawnCountPerWave;
    }

    bool IsEnemyRemaining()
    {
        if (GameObject.FindGameObjectWithTag("Enemy Plane") == null)
        {
            alreadySpawned = false;
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator holdForSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SpawnEnemies();
    }
}
