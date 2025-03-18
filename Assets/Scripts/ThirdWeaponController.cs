using UnityEngine;    
public class ThirdWeaponController : WeaponController
    {
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public override void Fire()
        {

        if (!TopShooterApplication.topShooterModel.weaponModel.CanFire) return;
        Debug.Log("Fire in Second Weapon Controller");

        var bullet = TopShooterApplication.topShooterModel.bulletPool.GetBullet();
        bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
        bullet.GetComponent<BulletController>().Activate();

        TopShooterApplication.topShooterModel.weaponModel.SetCanFire(false);
        fireCooldown = weaponModel.FireRate;
    }
   }
