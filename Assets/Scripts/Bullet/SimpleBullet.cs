using System;
using UnityEngine;

public class SimpleBullet : Element, IHit
{
    public Action OnBulletHit { get ; set; }
/// <summary>
/// Hit Enemy 
/// </summary>
/// <param name="Calls enemy take damage"></param>
    public void Hit(Collider2D other)
    {
        other.GetComponent<ItakeDamage>().TakeDamage(TopShooterApplication.topShooterModel.weaponModel.damage);
        OnBulletHit?.Invoke();
        TopShooterApplication.topShooterModel.simpleBullet.Return(gameObject);
    }
}
