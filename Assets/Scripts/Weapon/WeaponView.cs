using System;
using UnityEngine;

/// <summary>
/// handles new weapon equipment
/// </summary>
public class WeaponView : Element
{
    public WeaponType weaponType = WeaponType.TypeA;
    private WeaponController weaponController;
    private WeaponModel weaponModel;
    private WeaponFactory _weaponFactory;

    private void Start()
    {
        _weaponFactory = FindObjectOfType<WeaponFactory>(); 
        if (_weaponFactory == null)
        {
            Debug.LogError("WeaponView requires an IWeaponFactory implementation.");
        }

    }

    public void OnWeaponChange()
    {
        var weaponModel = _weaponFactory.CreateWeapon(weaponType);
        switch (weaponType)
        {
            case WeaponType.TypeA:
                weaponController = FindFirstObjectByType<FirstWeaponController>();
                break;
            case WeaponType.TypeB:
                weaponController = FindFirstObjectByType<SecondWeaponController>();

                break;
            case WeaponType.TypeC:
                weaponController = FindFirstObjectByType<ThirdWeaponController>();
                break;
        }
        if (weaponModel != null)
        {
            TopShooterApplication.topShooterController.weaponController.InitializeWeapon(weaponModel, weaponController);
        }
        else if(weaponModel == null)    
        {
            Debug.LogError("No Weapon Model Find!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && _weaponFactory != null)
        {
            switch (weaponType)
            {
                case WeaponType.TypeA:
                    weaponModel = FindFirstObjectByType<FirstWeaponModel>();
                    break;
                case WeaponType.TypeB:
                    weaponModel = FindFirstObjectByType<SecondWeaponModel>();

                    break;
                case WeaponType.TypeC:
                    weaponModel = FindFirstObjectByType<ThirdWeaponModel>();
                    break;
            }
            if (weaponModel != null)
            {
                TopShooterApplication.topShooterController.weaponController.Reload(weaponModel);
            }
            else if(weaponModel == null)    
            {
                Debug.LogError("No Weapon Model Find!");
            }
            Destroy(gameObject);
            TopShooterApplication.topShooterModel.simpleBullet.Return(other.gameObject);
        }
    }
}