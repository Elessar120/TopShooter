using System;
using UnityEngine;
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] float damage;
        ItakeDamage takeDamage;
        private void Awake()
        {
            takeDamage = GetComponent<ItakeDamage>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // attack player
            if (other.CompareTag("Player"))
            {   
                other.GetComponent<ItakeDamage>().TakeDamage(damage);
            }
            // enemy must died in order to exit the screen or collide with player
            if (other.CompareTag("Player") || other.CompareTag("Down"))
            {
                takeDamage.TakeDamage(int.MaxValue);
            }
            
        }

     
    }