using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Element, IHit
{
    public Action OnBulletHit { get ; set; }


    public void Hit(Collider2D other)
    {
        // Find all enemies in the explosion radius
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, TopShooterApplication.topShooterModel.weaponModel.explosionRadius, TopShooterApplication.topShooterModel.weaponModel.affectedLayers);
        foreach (Collider2D enemy in enemies)
        {
            // Apply force if enemie has Rigidbody2D
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (rb.transform.position - transform.position).normalized;
                rb.AddForce(direction * TopShooterApplication.topShooterModel.weaponModel.explosionForce, ForceMode2D.Impulse);
            }

            // Apply damage if the object implements IHit
            ItakeDamage hitEnemy = enemy.GetComponent<ItakeDamage>();
            if (hitEnemy != null)
            {
                hitEnemy.TakeDamage(TopShooterApplication.topShooterModel.weaponModel.damage);
            }
        }

        OnBulletHit?.Invoke();
        Destroy(this);
        TopShooterApplication.topShooterModel.bulletPool.ReturnBullet(gameObject);
        
    }
}
