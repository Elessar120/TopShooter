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
        if (TopShooterApplication.topShooterModel.weaponModel.Magazine <= 0) return;

        Debug.Log("Fire in third Weapon Controller");

        var bullet = TopShooterApplication.topShooterModel.explosiveBullet.Get();
        bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
        bullet.GetComponent<BulletController>().Activate();
        TopShooterApplication.topShooterModel.weaponModel.Magazine--;

        TopShooterApplication.topShooterModel.weaponModel.SetCanFire(false);
        fireRate = TopShooterApplication.topShooterModel.weaponModel.FireRate;
    }
   }
