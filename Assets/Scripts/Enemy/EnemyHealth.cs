using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, ItakeDamage
{ 
    public Action OnDeath { get; set; }
    [SerializeField] float maxHealth;
    [SerializeField] private float currentHealth;
    IReturnToPool returnToPool;
    
    private void Awake()
    {
        returnToPool = gameObject.GetComponent<IReturnToPool>();

    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// reduv=ce enemy health
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
        {
            currentHealth -= amount;    
            if (currentHealth <= 0)
            {
                OnDeath?.Invoke();
                ReturnToPool();
               
            }
        }

    private void ReturnToPool()
    {
        returnToPool.ReturnToPool();
    }
}
