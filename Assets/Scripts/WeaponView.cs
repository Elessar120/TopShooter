using System;
using UnityEngine;

public class WeaponView : Element
{
    public WeaponType weaponType = WeaponType.TypeA;
    public Action<WeaponModel> onWeaponChanged; 
    
    private IWeaponFactory _weaponFactory;

    private void Awake()
    {
        _weaponFactory = GetComponent<IWeaponFactory>(); 
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
            if (weaponModel != null)
            {
                onWeaponChanged?.Invoke(weaponModel);
            }
        }
    }
}