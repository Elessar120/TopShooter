using UnityEngine;

    public class FirstWeaponController : WeaponController
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


            var bullet = TopShooterApplication.topShooterModel.bulletPool.GetBullet();
            bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
            bullet.GetComponent<BulletController>().Activate();

        TopShooterApplication.topShooterModel.weaponModel.SetCanFire(false);
            fireCooldown = TopShooterApplication.topShooterModel.weaponModel.FireRate;
            Debug.Log("FirstWeaponController");
        }
    }