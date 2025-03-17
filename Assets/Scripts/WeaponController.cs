using System;
using System.Collections;
using UnityEngine;

public class WeaponController : Element
{
    protected WeaponModel weaponModel;
    protected float fireCooldown;
    public WeaponController currentWeapon;
    private void Start()
    {
        SubscribeToWeaponChanges();
        Initialize(FindObjectOfType<WeaponFactory>()?.CreateWeapon(WeaponType.TypeA), FindObjectOfType<FirstWeaponController>());
    }

    private void SubscribeToWeaponChanges()
    {
        foreach (var weaponView in TopShooterApplication.topShooterView.weaponView)
        {
            weaponView.onWeaponChanged += Initialize;
        }
    }


    public void Initialize(WeaponModel model, WeaponController weaponController)
    {
        weaponModel = model;
        fireCooldown = weaponModel.FireRate;
        if (currentWeapon == null)
        {
            currentWeapon = FindObjectOfType<FirstWeaponController>();
            Debug.Log("current weapon is null");
        }
        else
        {
            currentWeapon = weaponController;
            Debug.Log("Current Weapon : " + currentWeapon.name);
        }
    }

    private void Update()
    {
        if (!weaponModel.CanFire)
        {
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0)
            {
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