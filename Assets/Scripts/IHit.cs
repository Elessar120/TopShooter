using System;
using UnityEngine;

public interface IHit 
{    Action OnBulletHit { get; set; } 
    public void Hit(Collider2D other);
}
