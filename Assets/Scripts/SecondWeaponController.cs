using UnityEngine;

public class SecondWeaponController : WeaponController
{
    private float weaponHeat = 0f; // دمای فعلی سلاح
   
    private const float maxHeat = 1.0f; // حداکثر دما قبل از قفل شدن اسلحه
    private void Start()
    {
        
    }

    public void Update()
    {
        // کاهش دما در طول زمان
        if (weaponHeat > 0)
        {
            weaponHeat -= TopShooterApplication.topShooterModel.weaponModel.coolingRate * Time.deltaTime;
            weaponHeat = Mathf.Clamp(weaponHeat, 0f, maxHeat);
        }
    }

    public override void Fire()
    {
        if (!TopShooterApplication.topShooterModel.weaponModel.CanFire || weaponHeat >= maxHeat) return;
        Debug.Log("Fire in Second Weapon Controller");

        var bullet = TopShooterApplication.topShooterModel.bulletPool.GetBullet();
        bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
        bullet.GetComponent<BulletController>().Activate();

        // افزایش دمای سلاح پس از شلیک
        weaponHeat += TopShooterApplication.topShooterModel.weaponModel.heatPerShot;
        weaponHeat = Mathf.Clamp(weaponHeat, 0f, maxHeat);

        TopShooterApplication.topShooterModel.weaponModel.SetCanFire(false);
        fireCooldown = TopShooterApplication.topShooterModel.weaponModel.FireRate;
        Debug.Log("SecondWeaponController | Heat: " + weaponHeat);
    }
}