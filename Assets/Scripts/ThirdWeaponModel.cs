using UnityEngine;

    public class ThirdWeaponModel : WeaponModel
    {
        private WeaponController weaponController;
        public ThirdWeaponModel(float fireRate, int magazine) : base(fireRate, magazine)
        {
            weaponController = FindObjectOfType<ThirdWeaponController>();
        }
    }