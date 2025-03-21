using Unity.VisualScripting;
using UnityEngine;

public class SecondWeaponController : WeaponController
{
    private float weaponHeat = 0f;
    private const float maxHeat = 1.0f;
    private bool isOverheated = false;
    private float fireRateTimer = 0f; // Add a timer for fire rate cooldown
    private void Update()
    {
        // Handle heat cooldown
        if (weaponHeat >= 0)
        {
            weaponHeat -= TopShooterApplication.topShooterModel.weaponModel.coolingRate * Time.deltaTime;

            // Unlock weapon if heat is zero and it was overheated
            if (weaponHeat <= 0f && isOverheated)
            {
                isOverheated = false;
                TopShooterApplication.topShooterModel.weaponModel.SetCanFire(true);
            }
        }

        // Handle fire rate cooldown
        if (fireRateTimer > 0)
        {
              fireRateTimer -= Time.deltaTime;
            if (fireRateTimer <= 0)
            {
                if (!isOverheated)
                {
                    TopShooterApplication.topShooterModel.weaponModel.SetCanFire(true);
                }
            }
        }
    }

    public override void Fire()
    {
        if (isOverheated || !TopShooterApplication.topShooterModel.weaponModel.CanFire) return;
        if (TopShooterApplication.topShooterModel.weaponModel.Magazine <= 0) return;
        

        Debug.Log("Fire in Second Weapon Controller");

        var bullet = TopShooterApplication.topShooterModel.simpleBullet.Get();
        bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
        bullet.GetComponent<BulletController>().Activate();
        weaponHeat += TopShooterApplication.topShooterModel.weaponModel.heatPerShot;
        TopShooterApplication.topShooterModel.weaponModel.Magazine--;
        if (weaponHeat >= maxHeat)
        {
            isOverheated = true;
        }

        TopShooterApplication.topShooterModel.weaponModel.SetCanFire(false);
        fireRateTimer = TopShooterApplication.topShooterModel.weaponModel.FireRate;

    }
}