using UnityEngine;

/// <summary>
/// Factory class to create enemy prefabs based on type.
/// </summary>
public class EnemyFactory:MonoBehaviour
{
    GameObject enemy;
    /// <summary>
    /// Creates the correct enemy prefab based on the enemy type.
    /// </summary>
    /// <param name="type">The type of enemy to create.</param>
    /// <param name="greenEnemyPool">Prefab for the green enemy.</param>
    /// <param name="yellowEnemyPool">Prefab for the yellow enemy.</param>
    /// <param name="redEnemyPool">Prefab for the red enemy.</param>
    /// <returns>The GameObject prefab to instantiate, or null if the type is unknown.</returns>
    public GameObject CreateEnemy(int type, Pool greenEnemyPool, Pool yellowEnemyPool, Pool redEnemyPool)
    {
        switch (type)
        {
            case 1:
                enemy = greenEnemyPool.Get();
                enemy.GetComponent<EnemyPoolIdentifier>().currentPool = greenEnemyPool;
                return enemy;
            case 2:
                enemy = yellowEnemyPool.Get();
                enemy.GetComponent<EnemyPoolIdentifier>().currentPool = yellowEnemyPool;
                return enemy;           
            case 3:
                enemy = redEnemyPool.Get();
                enemy.GetComponent<EnemyPoolIdentifier>().currentPool = redEnemyPool;
                return enemy;              
            default:
                Debug.LogWarning("No prefab defined for enemy type: " + type);
                return null;
        }
    }
}