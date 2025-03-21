using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

/// <summary>
/// Manages the spawning of enemies based on data fetched from a remote server.
/// </summary>
public class EnemySpawnController : Element
{
    private const string WaveDataUrl = "http://www.profc.ir/users/shooterWaves";

    [FormerlySerializedAs("gruntPrefab")]
    [Header("Enemy Prefabs")]
    [Tooltip("Prefab for the basic grunt enemy.")]
    public Pool greenEnemyPool; //Enemy Type 1
    [Tooltip("Prefab for the elite enemy.")]
    public Pool YellowEnemyPool; //Enemy Type 2
    [Tooltip("Prefab for the strong enemy.")]
    public Pool redEnemyPool; //Enemy Type 3
    private SpawnDataWrapper spawnDataWrapper;
    private EnemyFactory factory;

    private void Awake()
    {
        TopShooterApplication.topShooterModel.isRunning = true;
        factory = FindFirstObjectByType<EnemyFactory>();
    }
    
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

        SetWinScore();
        if (spawnDataWrapper != null && spawnDataWrapper.data != null)
        {
            StartCoroutine(RunSpawnWaves());
        }
    }
/// <summary>
/// find it for win condition
/// </summary>
    private void SetWinScore()
    {
        int totalScore = 0;
        foreach (Wave wave in spawnDataWrapper.data.waves)
        {
            foreach (Enemy enemy in wave.enemy)
            {
                for (int i = 0; i < enemy.count; i++)
                {
                    totalScore++;
                }
            }
        }
        TopShooterApplication.topShooterController.scoreController.setScore((totalScore));
    }
    /// <summary>
    /// Coroutine to run the spawn waves based on the loaded data.
    /// </summary>
    private IEnumerator RunSpawnWaves()
    {
        foreach (Wave wave in spawnDataWrapper.data.waves)
        {
            // Process each enemy type within the wave
            foreach (Enemy enemy in wave.enemy)
            {
                for (int i = 0; i < enemy.count; i++)
                {
                    if (!TopShooterApplication.topShooterModel.isRunning)
                    {
                        yield break; // Exit the coroutine entirely if player dead
                    }

                    SpawnEnemy(enemy.type, GetRandomSpawnPosition()); // Spawn enemy at a random position
                    yield return new WaitForSeconds(2f); // Spawn rate
                }
            }
        }
    }

    /// <summary>
    /// Spawns an enemy of the specified type at the given position.
    /// </summary>
    /// <param name="type">The type of enemy to spawn (1: green, 2: yellow, 3: red).</param>
    /// <param name="spawnPosition">The position at which to spawn the enemy.</param>
    private void SpawnEnemy(int type, Vector2 spawnPosition)
    {
        //Factory Pattern Consideration
        GameObject prefabToSpawn = factory.CreateEnemy(type, greenEnemyPool, YellowEnemyPool, redEnemyPool);

        if (prefabToSpawn != null)
        {
            prefabToSpawn.transform.position = spawnPosition;
            prefabToSpawn.transform.rotation = Quaternion.identity;
            prefabToSpawn.GetComponent<ItakeDamage>().OnDeath += TopShooterApplication.topShooterController.scoreController.DecreaseScore;
            prefabToSpawn.SetActive(true);
        }
    }

    /// <summary>
    /// Gets a random spawn position within the game world.
    /// </summary>
    /// <returns>A random Vector2 spawn position.</returns>
    private Vector2 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(TopShooterApplication.topShooterModel.leftEdge.position.x + 1, TopShooterApplication.topShooterModel.rightEdge.position.x -1);
        float spawnY = TopShooterApplication.topShooterModel.topEdge.position.y; 

        return new Vector2(randomX, spawnY);
    }
}

