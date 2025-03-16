using System.Collections;
using UnityEngine;

public class BulletController : Element
{
    private Rigidbody2D rb;
    private float speed = 50;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float bulletSpeed)
    {
        speed = bulletSpeed;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        rb.velocity = Vector2.up * speed;
        StartCoroutine(DestroyBullet());
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(TopShooterApplication.topShooterModel.bulletModel.lifeTime);
        TopShooterApplication.topShooterModel.bulletPool.ReturnBullet(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.CompareTag("Enemy"))
        {
            // TODO: اعمال آسیب به دشمن
            gameObject.SetActive(false);
        }*/
    }
}