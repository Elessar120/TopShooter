using System;
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
        if (TopShooterApplication.topShooterModel.weaponModel.AmmoCount <= 0) return;
        Debug.Log("Fire in third Weapon Controller");

       
        if (TopShooterApplication.topShooterModel.thirdWeaponModel.AmmoCount > 0)
        {
            var bullet = TopShooterApplication.topShooterModel.explosiveBullet.Get();
            bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
            bullet.GetComponent<BulletController>().Activate();
            TopShooterApplication.topShooterModel.thirdWeaponModel.AmmoCount--;
            TopShooterApplication.topShooterController.gameplayUIController.UpdateWeaponAmmoUI(TopShooterApplication.topShooterModel.thirdWeaponModel);   
        }

        TopShooterApplication.topShooterModel.weaponModel.SetCanFire(false);
        fireRate = TopShooterApplication.topShooterModel.weaponModel.FireRate;
    }
   }
