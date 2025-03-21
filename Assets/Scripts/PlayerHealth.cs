using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ItakeDamage
{
    public Action OnDeath { get; set; }
    [SerializeField] float maxHealth;
    [SerializeField] private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
/// <summary>
/// reduce player's health in case of taking damage
/// </summary>
/// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            FindFirstObjectByType<TopShooterApplication>().topShooterModel.isRunning = false;
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
