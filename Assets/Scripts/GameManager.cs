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

    private int spawnedCount = 0;
    private int spawnLimit = 1;
    private int waveCount = 5;
    static private int _score;

    [SerializeField] List<GameObject> enemyPrefabs;

    private void Awake()
    {
        //InvokeRepeating("SpawnEnemies", 1, intervalTime); I have stopped using it because it is hard to change afterwards
        StartCoroutine(SpawnEnemiesEnum(5, 2, 3));
        waveCount = 5;
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
        // Currentily Changing it to IEnum
            int numbersToSpawn = CalculateSpawning();

            for (int i = 0; i < numbersToSpawn; i++)
            {
                float RandomXSpawnPosition = Random.Range(0, 2) == 0 ? xPos : -xPos;
                float RandomYSpawnPosition = Random.Range(minY, maxY + 1);
                GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

                GameObject chosenPrefab = Instantiate(randomPrefab, new Vector2(RandomXSpawnPosition, RandomYSpawnPosition), randomPrefab.transform.rotation);
                Rigidbody2D chosenPrefabRb = chosenPrefab.GetComponent<Rigidbody2D>();

                if (RandomXSpawnPosition == xPos)
                {
                    Flip(chosenPrefab); // plane will flipp when it is coming from right
                    chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.left);
                }
                else
                {
                    chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.right);
                }
            spawnLimit++;
            }
            alreadySpawned = true;
        
    }

    int CalculateSpawning()
    {
        int EnemyspawnCountPerWave = 1;
        for (int i = 0; i < waveCount; i++)
        {
            EnemyspawnCountPerWave *= 2;
        }
        spawnLimit = EnemyspawnCountPerWave;
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

    void Flip(GameObject objectToFlip)
    {
        Vector2 theScale = objectToFlip.transform.localScale;
        theScale.x *= -1;
        objectToFlip.transform.localScale = theScale;

    }

    void ObjectMove(Rigidbody2D rBToMove, Vector2 objectVelocity)
    {
        rBToMove.velocity = objectVelocity;
    }


    IEnumerator holdForSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SpawnEnemies();
    }

    IEnumerator SpawnEnemiesEnum (int numToSpawn, int intervalTime, int secondsToStart)
    {
        yield return new WaitForSeconds (secondsToStart);
        while (spawnedCount != spawnLimit)
        {
            int numbersToSpawn = CalculateSpawning();

            for (int i = 0; i < numbersToSpawn; i++)
            {
                float RandomXSpawnPosition = Random.Range(0, 2) == 0 ? xPos : -xPos;
                float RandomYSpawnPosition = Random.Range(minY, maxY + 1);
                GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

                GameObject chosenPrefab = Instantiate(randomPrefab, new Vector2(RandomXSpawnPosition, RandomYSpawnPosition), randomPrefab.transform.rotation);
                Rigidbody2D chosenPrefabRb = chosenPrefab.GetComponent<Rigidbody2D>();

                if (RandomXSpawnPosition == xPos)
                {
                    Flip(chosenPrefab); // plane will flipp when it is coming from right
                    chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.left);
                }
                else
                {
                    chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.right);
                }
                spawnedCount++;
                yield return new WaitForSeconds (intervalTime);
            }
            alreadySpawned = true;
        }
    }
}
