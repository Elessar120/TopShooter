using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/// <summary>
/// Manages the spawning of enemies based on data fetched from a remote server.
/// </summary>
public class SpawnManager : MonoBehaviour
{
    private const string WaveDataUrl = "http://www.profc.ir/users/shooterWaves";

    [Header("Enemy Prefabs")]
    [Tooltip("Prefab for the basic grunt enemy.")]
    public GameObject gruntPrefab; //Enemy Type 1
    [Tooltip("Prefab for the elite enemy.")]
    public GameObject elitePrefab; //Enemy Type 2
    [Tooltip("Prefab for the strong enemy.")]
    public GameObject strongPrefab; //Enemy Type 3

    private SpawnDataWrapper spawnDataWrapper;

    /// <summary>
    /// Initializes the spawn manager by starting the coroutine to load spawn data.
    /// </summary>
    void Start()
    {
        StartCoroutine(LoadSpawnData());
    }

    /// <summary>
    /// Coroutine to fetch wave data from the server and process it.
    /// </summary>
    private IEnumerator LoadSpawnData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(WaveDataUrl))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Failed to load wave data: {request.error}");
                yield break;
            }

            string json = request.downloadHandler.text;
            Debug.Log("JSON Data: " + json); // Log the JSON for debugging
            spawnDataWrapper = JsonUtility.FromJson<SpawnDataWrapper>(json);

            if (spawnDataWrapper == null || spawnDataWrapper.data == null || spawnDataWrapper.data.waves == null)
            {
                Debug.LogError("Invalid or empty spawn data received!");
            }
        }
        if (spawnDataWrapper != null && spawnDataWrapper.data != null)
        {
            StartCoroutine(RunSpawnWaves());
        }
    }

    /// <summary>
    /// Coroutine to run the spawn waves based on the loaded data.
    /// </summary>
    private IEnumerator RunSpawnWaves()
    {
        Debug.Log("1");
        Debug.Log(spawnDataWrapper);
        Debug.Log(spawnDataWrapper.data.waves);
        Debug.Log(spawnDataWrapper.data.waves.Count);

        foreach (Wave wave in spawnDataWrapper.data.waves)
        {
            Debug.Log("2");

            // Process each enemy type within the wave
            foreach (Enemy enemy in wave.enemy)
            {
                Debug.Log("3");

                for (int i = 0; i < enemy.count; i++)
                {
                    Debug.Log("4");
                    SpawnEnemy(enemy.type, GetRandomSpawnPosition()); // Spawn enemy at a random position
                    yield return new WaitForSeconds(2f); //you need to get spawn rate from json but there is no spawn rate in json
                }
            }
        }
    }

    /// <summary>
    /// Spawns an enemy of the specified type at the given position.
    /// </summary>
    /// <param name="type">The type of enemy to spawn (1: Grunt, 2: Elite, 3: Strong).</param>
    /// <param name="spawnPosition">The position at which to spawn the enemy.</param>
    private void SpawnEnemy(int type, Vector2 spawnPosition)
    {
        //Factory Pattern Consideration
        GameObject prefabToSpawn = EnemyPrefabFactory.CreateEnemyPrefab(type, gruntPrefab, elitePrefab, strongPrefab);

        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    /// <summary>
    /// Gets a random spawn position within the game world.
    /// </summary>
    /// <returns>A random Vector2 spawn position.</returns>
    private Vector2 GetRandomSpawnPosition()
    {
        // You'll need to define how enemies spawn in your game world.
        // This is a placeholder. You might want to spawn enemies at the top
        // of the screen at a random x position.

        float randomX = Random.Range(-5f, 5f); // Example: Random x within -5 to 5
        float spawnY = 7f; // Example: Spawn at y = 7

        return new Vector2(randomX, spawnY);
    }
}

