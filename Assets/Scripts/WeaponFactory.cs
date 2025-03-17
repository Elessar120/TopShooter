using UnityEngine;

public class WeaponFactory : MonoBehaviour, IWeaponFactory
{
    public WeaponData[] weaponConfigs; // Assign ScriptableObjects in the Inspector

    public WeaponModel CreateWeapon(WeaponType type)
    {
        Debug.Log("WeaponType type : " + type);
        WeaponData config = null;
        foreach (var weapon in weaponConfigs)
        {
            if (weapon.weaponType == type)
            {
                config = weapon;
                break; // Stop at the first match
            }
        }
        Debug.Log("Weapon Data Config : " + config.name);
        if (config != null)
        {
            return new WeaponModel(config.fireRate, config.magazine);
        }
        else
        {
            return null;
        }
     
    }
}