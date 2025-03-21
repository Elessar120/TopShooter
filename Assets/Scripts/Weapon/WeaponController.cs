using System.Collections;
using UnityEngine;

public class WeaponController : Element
{
    public WeaponModel weaponModel;
    protected float fireRate;
    public WeaponController currentWeapon;
    private void Start()
    {
        Initialize(FindObjectOfType<WeaponFactory>()?.CreateWeapon(WeaponType.TypeA), FindObjectOfType<FirstWeaponController>() as WeaponController);
    }

    public void SubscribeToWeaponChanges(WeaponView weaponView)
    {
       weaponView.onWeaponChanged += Initialize;
    }

    private void Initialize(WeaponModel model, WeaponController weaponController)
    {
        weaponModel = model;
        fireRate = weaponModel.FireRate;
        currentWeapon = weaponController;

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