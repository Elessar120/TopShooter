using System;
using UnityEngine;

public class SimpleBullet : Element, IHit
{
    public Action OnBulletHit { get ; set; }

    public void Hit(Collider2D other)
    {
        other.GetComponent<Health>().TakeDamage(TopShooterApplication.topShooterModel.weaponModel.damage);
        OnBulletHit?.Invoke();
        Destroy(this);
        TopShooterApplication.topShooterModel.bulletPool.ReturnBullet(gameObject);
    }
}
