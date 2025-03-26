
using UnityEngine;

public class SecondWeaponController : WeaponController
{
    private float weaponHeat = 0f;
    private const float maxHeat = 1.0f;
    private bool isOverheated = false;
    private float fireRateTimer = 0f; // Add a timer for fire rate cooldown
    private void Update()
    {
        Debug.Log("Update in secondweaponcontroller");
        // Handle heat cooldown
        if (weaponHeat >= 0)
        {
            weaponHeat -= TopShooterApplication.topShooterModel.secondWeaponModel.coolingRate * Time.deltaTime;

            // Unlock weapon if heat is zero and it was overheated
            if (weaponHeat <= 0f && isOverheated)
            {
                isOverheated = false;
                TopShooterApplication.topShooterModel.weaponModel.SetCanFire(true);
                TopShooterApplication.topShooterController.gameplayUIController.OnWeaponCoolUIChange();
            }
        }

        // Handle fire rate cooldown
    }

    public override void Fire()
    {
        if (isOverheated || !TopShooterApplication.topShooterModel.weaponModel.CanFire) return;
        if (TopShooterApplication.topShooterModel.weaponModel.AmmoCount <= 0) return;

        Debug.Log("Fire in Second Weapon Controller");

      
        if (TopShooterApplication.topShooterModel.secondWeaponModel.AmmoCount > 0)
        {
            var bullet = TopShooterApplication.topShooterModel.simpleBullet.Get();
            bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
            bullet.GetComponent<BulletController>().Activate();
            weaponHeat += TopShooterApplication.topShooterModel.weaponModel.heatPerShot;
            TopShooterApplication.topShooterModel.secondWeaponModel.AmmoCount--;
            TopShooterApplication.topShooterController.gameplayUIController.UpdateWeaponAmmoUI(TopShooterApplication.topShooterModel.secondWeaponModel);
        }
      
        if (weaponHeat >= maxHeat)
        {
            isOverheated = true;
            TopShooterApplication.topShooterController.gameplayUIController.OnWeaponHeatUIChange();
        }

        TopShooterApplication.topShooterModel.weaponModel.SetCanFire(false);
        fireRateTimer = TopShooterApplication.topShooterModel.weaponModel.FireRate;

    }
}