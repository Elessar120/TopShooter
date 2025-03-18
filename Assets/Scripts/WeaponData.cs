using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public WeaponType weaponType;
    public float fireRate;
    public int magazine;
    public float heatPerShot = 0.05f; 
    public float coolingRate = 0.025f; 
}