using UnityEngine;

public class WeaponFactory : MonoBehaviour, IWeaponFactory
{
    public WeaponData[] weaponConfigs; // Assign ScriptableObjects in the Inspector

    public WeaponModel CreateWeapon(WeaponType type)
    {
        WeaponData config = System.Array.Find(weaponConfigs, w => w.weaponType == type);
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