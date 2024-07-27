using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// The wave system is adaptable based on the wave round as it myltiply based on the wave number. 
/// TO DO:
/// - Score System need to be imlemented. In order to the scoring system I beilive I need to create ScriptableObject for them and give behaviors by script
/// - Overall Enemy Spawn Proababilty be added to game. as for example bomber less chance of spawn.
/// Note: NUI = Not in use (yet)
///       As is = It is obvious 
/// </summary>

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isSpawnedRight;
    public TextMeshProUGUI waveText;
    public float maxBorderX = 16;

    [SerializeField] float xPos = 10;
    [SerializeField] float maxY = 10;
    [SerializeField] float minY = 5;
    [SerializeField] int intervalTime = 3;
    [SerializeField] int waveSpawnModifier = 5;
   
    private int currentWave;
    private int enemiesToSpawn;
    private int enemiesRemaining;
    
    static private int _score; //NIU

    [SerializeField] List<GameObject> enemyPrefabs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // I will add this in case we want to change scenes then gameManager won't get destroyed while loading other scenes
        }
        else
        {
            Destroy(gameObject); // if there is an instance there it will destroy
        }
    }

    private void Start()
    {
        StartNextWave();
    }


    void StartNextWave() // As is
    {
        currentWave++;
        enemiesToSpawn = currentWave * waveSpawnModifier;
        enemiesRemaining = enemiesToSpawn;
        waveText.text = "Wave: " + currentWave;
        StartCoroutine("SpawnEnemiesEnum");
    }

    IEnumerator SpawnEnemiesEnum() // I just seperated the loop from the SpawnEnemies Function to make a better WaitforSeconds(I guess it's more stable like this)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(Random.Range(0, intervalTime));
        }
    }
    public void enemyDestroyed() //As is 
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            StartNextWave();
        }
    }
    public void Flip(GameObject objectToFlip) // will flip any 2d object
    {
        Vector2 theScale = objectToFlip.transform.localScale;
        theScale.x *= -1;
        objectToFlip.transform.localScale = theScale;

    }
    void SpawnEnemies()
    {
        // Randomize Position & GameObject
        float RandomXSpawnPosition = Random.Range(0, 2) == 0 ? xPos : -xPos;
        float RandomYSpawnPosition = Random.Range(minY, maxY + 1);
        GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // Instantiate & get RigidBody
        GameObject chosenPrefab = Instantiate(randomPrefab, new Vector2(RandomXSpawnPosition, RandomYSpawnPosition), randomPrefab.transform.rotation);
        Rigidbody2D chosenPrefabRb = chosenPrefab.GetComponent<Rigidbody2D>();

        if (RandomXSpawnPosition == xPos)
        {
            Flip(chosenPrefab); // plane will flipp when it is coming from right
            chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.left);
            isSpawnedRight = true;
        }
        else
        {
            isSpawnedRight = false;
            chosenPrefabRb.velocity = chosenPrefab.transform.TransformDirection(Vector2.right);
        }

    }

    void ChangeDirectionWhileAtBorder()
    {
        
    }
    
    void WaveCountUp()
    {
        currentWave++;

    } // NIU

 

    int CalculateSpawning()
    {
        int EnemyspawnCountPerWave = 1;
        for (int i = 0; i < currentWave; i++)
        {
            EnemyspawnCountPerWave *= 2;
        }
        return EnemyspawnCountPerWave;
    } // NIU

    bool IsEnemyRemaining() //NIU
    {
        if (GameObject.FindGameObjectWithTag("Enemy Plane") == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void ObjectMove(Rigidbody2D rBToMove, Vector2 objectVelocity) // NIU
    {
        rBToMove.velocity = objectVelocity;
    }


    IEnumerator holdForSeconds(int seconds) // NIU
    {
        yield return new WaitForSeconds(seconds);
        SpawnEnemies();
    }

    IEnumerator SpawnEnemiesFromDifferentLocation(int numToSpawn, int intervalTime, int secondsToStart) // NIU (An enumerator replica of the function of SpawnEnemies)
    {
        yield return new WaitForSeconds(secondsToStart);

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
        
    }
  
}
