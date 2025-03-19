using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : MonoBehaviour
{
    private const string WaveDataURL = "http://www.profc.ir/users/shooterWaves";

    [Header("Enemy Prefabs")]
    public GameObject gruntPrefab; //Enemy Type 1
    public GameObject elitePrefab; //Enemy Type 2
    public GameObject strongPrefab; //Enemy Type 3

    private SpawnDataWrapper spawnDataWrapper;

    void Start()
    {
        StartCoroutine(LoadSpawnData());
    }

    private IEnumerator LoadSpawnData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(WaveDataURL))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Failed to load wave data: {request.error}");
                yield break;
            }

            string json = request.downloadHandler.text;
            Debug.Log("JSON Data: " + json); // Log the JSON
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

    private IEnumerator RunSpawnWaves()
    {
        Debug.Log("1");
        Debug.Log(spawnDataWrapper);
        Debug.Log(spawnDataWrapper.data.waves);
        Debug.Log(spawnDataWrapper.data.waves.Count);

        foreach (Wave wave in spawnDataWrapper.data.waves)
        {
            Debug.Log("2");

            // Process each enemy group within the wave
            foreach (Enemy enemy in wave.enemy)
            {
                Debug.Log("3");

                for (int i = 0; i < enemy.count; i++)
                {
                    Debug.Log("4");
                    //removed positions

                    SpawnEnemy(enemy.type, GetRandomSpawnPosition()); // Get Random Spawn Position
                    yield return new WaitForSeconds(2f); //you need to get spawn rate from json but there is no spawn rate in json
                }
            }
        }
    }

    private void SpawnEnemy(int type, Vector2 spawnPosition)
    {
        GameObject prefabToSpawn = null;
        Debug.Log("5");

        switch (type)
        {
            case 1:
                prefabToSpawn = gruntPrefab;
                break;
            case 2:
                prefabToSpawn = elitePrefab;
                break;
            case 3:
                prefabToSpawn = strongPrefab;
                break;
            default:
                Debug.LogWarning("No prefab defined for enemy type: " + type);
                break;
        }

        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

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