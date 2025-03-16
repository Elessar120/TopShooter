using System;
using UnityEngine;

public class WeaponView : Element
{
    public WeaponType weaponType = WeaponType.TypeA;
    public Action<WeaponModel, WeaponController> onWeaponChanged;
    private WeaponController weaponController;
    private IWeaponFactory _weaponFactory;

    private void Awake()
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
                    weaponController = FindObjectOfType<FirstWeaponController>();
                    break;
                case WeaponType.TypeB:
                    weaponController = FindObjectOfType<SecondWeaponController>();
                    
                    break;
                case WeaponType.TypeC:
                    weaponController = FindObjectOfType<ThirdWeaponController>();

                    break;
            }
            if (weaponModel != null)
            {
                onWeaponChanged?.Invoke(weaponModel, weaponController);
                Debug.Log(weaponModel);
            }
        }
    }
}