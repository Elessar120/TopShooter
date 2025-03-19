using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnManager : Element
{
    [Header("Spawn Settings")]
    public GameObject[] objectsToSpawn; // The prefab to spawn
    public Transform[] spawnPoints;  // Possible spawn locations
    public float spawnInterval = 5f; // Time interval for automatic spawning
    public int maxObjects = 10;      // Max objects in the scene at a time

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start()
    {
        // Start automatic spawning
        StartCoroutine(SpawnOverTime());
    }

    private IEnumerator SpawnOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (spawnedObjects.Count < maxObjects)
            {
                SpawnObject();
            }
        }
    }

    public void SpawnObject()
    {
        if (spawnPoints.Length == 0 || objectsToSpawn == null)
        {
            Debug.LogWarning("No spawn points or object assigned!");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawned = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], spawnPoint.position, spawnPoint.rotation);
        WeaponView weaponView = spawned.GetComponent<WeaponView>();
        //TopShooterApplication.topShooterView.weaponView.Add(weaponView);
        TopShooterApplication.topShooterController.weaponController.SubscribeToWeaponChanges(weaponView);
        spawnedObjects.Add(spawned);

    }

    public void SpawnOnEnemyDeath()
    {
        if (spawnedObjects.Count < maxObjects)
        {
            SpawnObject();
        }
    }
}
