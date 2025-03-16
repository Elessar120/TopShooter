using UnityEngine;

    public class SecondWeaponModel : WeaponModel
    {
        private WeaponController weaponController;
        public SecondWeaponModel(float fireRate, int magazine) : base(fireRate, magazine)
        {
            weaponController = FindObjectOfType<SecondWeaponController>();
        }
    }