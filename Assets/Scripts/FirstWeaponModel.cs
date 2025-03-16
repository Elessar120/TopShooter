using UnityEngine;

    public class FirstWeaponModel : WeaponModel
    {
        private WeaponController weaponController;
        public FirstWeaponModel(float fireRate, int magazine) : base(fireRate, magazine)
        {
        }
    }