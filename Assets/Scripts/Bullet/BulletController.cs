using System.Collections;
using UnityEngine;

public class BulletController : Element
{
    private Rigidbody2D rb;
    private float speed = 50;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
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
        TopShooterApplication.topShooterModel.simpleBullet.Return(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

       if(other.CompareTag("Enemy"))
       {
           GetComponent<IHit>().Hit(other);
       }
    }
}