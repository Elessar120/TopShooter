using System;
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
            if (TopShooterApplication.topShooterModel.weaponModel.AmmoCount <= 0) return;

          
            if (TopShooterApplication.topShooterModel.firstWeaponModel.AmmoCount > 0)
            {
                var bullet = TopShooterApplication.topShooterModel.simpleBullet.Get();
                bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
                bullet.GetComponent<BulletController>().Activate();
                TopShooterApplication.topShooterModel.firstWeaponModel.AmmoCount--;
                TopShooterApplication.topShooterController.gameplayUIController.UpdateWeaponAmmoUI(TopShooterApplication.topShooterModel.firstWeaponModel);
            }
           

            TopShooterApplication.topShooterModel.weaponModel.SetCanFire(false);
            fireRate = TopShooterApplication.topShooterModel.weaponModel.FireRate;
            Debug.Log("Fire in first Controller");
        }
    }