using UnityEngine;

public class WeaponModel:Element
{
    public float FireRate;
    public int Magazine;
    public bool CanFire;
    public WeaponType weaponType;
    public BulletType bulletType;
    public float heatPerShot = 0.05f;
    public float coolingRate = 0.025f;
    public float damage;
    public float explosionRadius = 5f;
    public float explosionForce = 10f;
    public LayerMask affectedLayers;
    public void SetCanFire(bool value)
    {
        CanFire = value;
    }
}