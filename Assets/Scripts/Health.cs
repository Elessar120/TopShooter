using System;
using UnityEngine;

public class Health : MonoBehaviour, ItakeDamage
{ 
    public Action OnDeath { get; set; }
    [SerializeField] float maxHealth;
    private float currentHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
               OnDeath?.Invoke();
               Destroy(gameObject);
            }
        }
    }
