using UnityEngine;

public class WeaponFactory : MonoBehaviour, IWeaponFactory
{
    public WeaponModel CreateWeapon(WeaponType type)
    {
        return type switch
        {
            WeaponType.TypeA => FindObjectOfType<FirstWeaponModel>(),
            WeaponType.TypeB => FindObjectOfType<SecondWeaponModel>(),
            WeaponType.TypeC => FindObjectOfType<ThirdWeaponModel>(),
            _ => null
        };
    }
}