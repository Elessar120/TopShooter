using UnityEngine;

/// <summary>
/// Factory class to create enemy prefabs based on type.
/// </summary>
public static class EnemyPrefabFactory
{
    /// <summary>
    /// Creates the correct enemy prefab based on the enemy type.
    /// </summary>
    /// <param name="type">The type of enemy to create.</param>
    /// <param name="gruntPrefab">Prefab for the grunt enemy.</param>
    /// <param name="elitePrefab">Prefab for the elite enemy.</param>
    /// <param name="strongPrefab">Prefab for the strong enemy.</param>
    /// <returns>The GameObject prefab to instantiate, or null if the type is unknown.</returns>
    public static GameObject CreateEnemyPrefab(int type, GameObject gruntPrefab, GameObject elitePrefab, GameObject strongPrefab)
    {
        switch (type)
        {
            case 1:
                return gruntPrefab;
            case 2:
                return elitePrefab;
            case 3:
                return strongPrefab;
            default:
                Debug.LogWarning("No prefab defined for enemy type: " + type);
                return null;
        }
    }
}