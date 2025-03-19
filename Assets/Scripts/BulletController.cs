using System.Collections;
using UnityEngine;

public class BulletController : Element
{
    private Rigidbody2D rb;
    private float speed = 50;
    private IHit hitEnemy;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hitEnemy = GetComponent<IHit>();
    }

    public void Initialize(float bulletSpeed)
    {
        speed = bulletSpeed;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        rb.linearVelocity = Vector2.up * speed;
        StartCoroutine(DestroyBullet());
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(TopShooterApplication.topShooterModel.bulletModel.lifeTime);
        TopShooterApplication.topShooterModel.bulletPool.ReturnBullet(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Enemy"))
       {
           hitEnemy.Hit(other);
       }

       if (other.CompareTag("WeaponBox"))
       {
           
       }
    }
}