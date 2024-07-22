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
                    Flip(chosenPrefab); // plane will flip when it is coming from right
                    chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.left);
                }
                else
                {
                    chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.right);
                }
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
}
