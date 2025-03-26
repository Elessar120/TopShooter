using System;
using System.Collections;
using UnityEngine;

public class WeaponController : Element
{
    public WeaponModel weaponModel;
    protected float fireRate;
    public WeaponController currentWeapon;
    private void Start()
    {
        InitializeWeapon(FindObjectOfType<WeaponFactory>()?.CreateWeapon(WeaponType.TypeA), FindObjectOfType<FirstWeaponController>() as WeaponController);
    }
    
    public void InitializeWeapon(WeaponModel model, WeaponController weaponController)
    {
        weaponModel = model;
        fireRate = weaponModel.FireRate;
        currentWeapon = weaponController;
        TopShooterApplication.topShooterController.gameplayUIController.UpdateWeaponAmmoUI(weaponModel);
    }
    public void Reload(WeaponModel model)
    {
        model.AmmoCount = model.Magazine;
        TopShooterApplication.topShooterController.gameplayUIController.UpdateWeaponAmmoUI(model);
    }

    private void Update()
    {
        if (!weaponModel.CanFire)
        {
            fireRate -= Time.deltaTime; 

            if (fireRate <= 0)
            {
                fireRate = weaponModel.FireRate; // Reset cooldown properly
                weaponModel.SetCanFire(true);
            }
        }
        
    }

    public virtual void Fire()
    {
    }
    
}