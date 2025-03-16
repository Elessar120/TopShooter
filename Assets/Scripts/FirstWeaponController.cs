using UnityEngine;

    public class FirstWeaponController : WeaponController
    {
        public override void Fire()
        {
            if (!weaponModel.CanFire) return;


            var bullet = TopShooterApplication.topShooterModel.bulletPool.GetBullet();
            bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
            bullet.GetComponent<BulletController>().Activate();

            weaponModel.SetCanFire(false);
            fireCooldown = weaponModel.FireRate;
            Debug.Log("FirstWeaponController");
        }
    }