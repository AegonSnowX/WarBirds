using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isSpawnedRight;
    public TextMeshProUGUI waveText;

    [SerializeField] float xPos = 10;
    [SerializeField] float maxY = 10;
    [SerializeField] float minY = 5;
    [SerializeField] int intervalTime = 3;
    [SerializeField] int waveSpawnModifier = 5;

    private bool alreadySpawned;

    private int spawnedCount = 0;
    private int spawnLimit = 1;
    
    private int currentWave;
    private int enemiesToSpawn;
    private int enemiesRemaining;
    static private int _score;

    [SerializeField] List<GameObject> enemyPrefabs;

    private void Start()
    {
        StartNextWave();
    }


    void StartNextWave() // As is
    {
        currentWave++;
        enemiesToSpawn = currentWave * waveSpawnModifier;
        enemiesRemaining = enemiesToSpawn;
        waveText.text = "Wave:" + currentWave;
        StartCoroutine("SpawnEnemiesEnum");
    }

    IEnumerator SpawnEnemiesEnum()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(Random.Range(0, intervalTime));
        }
    }

    void WaveCountUp()
    {
        currentWave++;

    }

    void SpawnEnemies()
    {
        // Currentily Changing it to IEnum
        // Currently Using it again
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
        alreadySpawned = true;

    }

    int CalculateSpawning()
    {
        int EnemyspawnCountPerWave = 1;
        for (int i = 0; i < currentWave; i++)
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

    IEnumerator SpawnEnemiesFromDifferentLocation(int numToSpawn, int intervalTime, int secondsToStart)
    {
        yield return new WaitForSeconds(secondsToStart);
        while (spawnedCount != spawnLimit)
        {
            //int numbersToSpawn = CalculateSpawning();

            float RandomXSpawnPosition = Random.Range(0, 2) == 0 ? xPos : -xPos;
            float RandomYSpawnPosition = Random.Range(minY, maxY + 1);
            GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

            GameObject chosenPrefab = Instantiate(randomPrefab, new Vector2(RandomXSpawnPosition, RandomYSpawnPosition), randomPrefab.transform.rotation);
            Rigidbody2D chosenPrefabRb = chosenPrefab.GetComponent<Rigidbody2D>();

            if (RandomXSpawnPosition == xPos)
            {
                isSpawnedRight = true;
                Flip(chosenPrefab); // plane will flipp when it is coming from right
                chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.left);
            }
            else
            {
                isSpawnedRight = false;
                chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.right);
            }
            yield return new WaitForSeconds(intervalTime);

            alreadySpawned = true;
        }
    }
    public void enemyDestroyed()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            StartNextWave();
        }
    }
}
