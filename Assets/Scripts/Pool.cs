using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject Prefab; 
    public int poolSize = 20; 

    private Queue<GameObject> bulletPool;

    void Awake()
    {
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(Prefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject Get()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            return bullet;
        }
        else
        {
            GameObject bullet = Instantiate(Prefab);
            return bullet;
        }
    }

    public void Return(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
