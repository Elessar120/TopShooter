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
            if (TopShooterApplication.topShooterModel.weaponModel.Magazine <= 0) return;


            var bullet = TopShooterApplication.topShooterModel.simpleBullet.Get();
            bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
            bullet.GetComponent<BulletController>().Activate();
            TopShooterApplication.topShooterModel.weaponModel.Magazine--;

        TopShooterApplication.topShooterModel.weaponModel.SetCanFire(false);
            fireRate = TopShooterApplication.topShooterModel.weaponModel.FireRate;
            Debug.Log("Fire in first Controller");
        }
    }