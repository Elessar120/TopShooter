using System;
using UnityEngine;

public class Bullet : Element
{
    public Rigidbody2D rigidbody2D;

    private void Awake()
    {
        if (rigidbody2D == null)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
    
    public void Activate()
    {
        gameObject.SetActive(true);
        rigidbody2D.AddForceY(TopShooterApplication.topShooterModel.bulletModel.speed * Time.fixedDeltaTime, ForceMode2D.Impulse);

    }
}
