using UnityEngine;

public class SecondWeaponController : WeaponController
{
    private float weaponHeat = 0f; // دمای فعلی سلاح
    private const float heatPerShot = 0.05f; // مقدار افزایش دما در هر شلیک
    private const float coolingRate = 0.025f; // نرخ خنک شدن در هر ثانیه
    private const float maxHeat = 1.0f; // حداکثر دما قبل از قفل شدن اسلحه

    public void Update()
    {
        // کاهش دما در طول زمان
        if (weaponHeat > 0)
        {
            weaponHeat -= coolingRate * Time.deltaTime;
            weaponHeat = Mathf.Clamp(weaponHeat, 0f, maxHeat);
        }
    }

    public override void Fire()
    {
        if (!weaponModel.CanFire || weaponHeat >= maxHeat) return;
        Debug.Log("Fire");

        var bullet = TopShooterApplication.topShooterModel.bulletPool.GetBullet();
        bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.position;
        bullet.GetComponent<BulletController>().Activate();

        // افزایش دمای سلاح پس از شلیک
        weaponHeat += heatPerShot;
        weaponHeat = Mathf.Clamp(weaponHeat, 0f, maxHeat);

        weaponModel.SetCanFire(false);
        fireCooldown = weaponModel.FireRate;
        Debug.Log("SecondWeaponController | Heat: " + weaponHeat);
    }
}