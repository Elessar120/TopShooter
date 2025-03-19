using System;
using System.Collections;
using UnityEngine;

public class WeaponController : Element
{
    public WeaponModel weaponModel;
    protected float fireCooldown;
    public WeaponController currentWeapon;
    private void Start()
    {
        Initialize(FindObjectOfType<WeaponFactory>()?.CreateWeapon(WeaponType.TypeA), FindObjectOfType<FirstWeaponController>() as WeaponController);
    }

    public void SubscribeToWeaponChanges(WeaponView weaponView)
    {
       weaponView.onWeaponChanged += Initialize;
    }   

    public void UnSubscribeToWeaponChanges(WeaponView weaponView)
    {
            weaponView.onWeaponChanged -= Initialize;
    }

    public void Initialize(WeaponModel model, WeaponController weaponController)
    {
        weaponModel = model;
        fireCooldown = weaponModel.FireRate;
        currentWeapon = weaponController;
//        Debug.Log(currentWeapon.name);

    }

    private void Update()
    {
        if (!weaponModel.CanFire)
        {
            fireCooldown -= Time.deltaTime; 

            if (fireCooldown <= 0)
            {
                fireCooldown = weaponModel.FireRate; // Reset cooldown properly
                weaponModel.SetCanFire(true);
            }
        }
    }

    public virtual void Fire()
    {
       Debug.Log("Fire");
       
       // StartCoroutine(DestroyBullet(bullet));
        
    }

    private IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(TopShooterApplication.topShooterModel.bulletModel.lifeTime);
        bullet.SetActive(false); // به جای Destroy استفاده شود
    }
}