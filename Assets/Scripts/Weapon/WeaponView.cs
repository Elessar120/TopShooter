using System;
using UnityEngine;

/// <summary>
/// handles new weapon equipment
/// </summary>
public class WeaponView : Element
{
    public WeaponType weaponType = WeaponType.TypeA;
    public Action<WeaponModel, WeaponController> onWeaponChanged;
    private WeaponController weaponController;
    private WeaponFactory _weaponFactory;

    private void Start()
    {
        _weaponFactory = FindObjectOfType<WeaponFactory>(); 
        if (_weaponFactory == null)
        {
            Debug.LogError("WeaponView requires an IWeaponFactory implementation.");
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && _weaponFactory != null)
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
                onWeaponChanged.Invoke(weaponModel, weaponController);
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