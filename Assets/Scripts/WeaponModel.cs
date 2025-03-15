using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponModel : Element
    {
        public float fireRate;
        public int magazine;
        public WeaponModel currentWeapon;
        public bool canFire;

        private void Start()
        {
            TopShooterApplication.topShooterView.weaponView.onWeaponChanged += SetWeapon;
            canFire = true;
            SetWeapon(FindObjectOfType<FirstWeaponModel>());
        }
        public void SetWeapon(WeaponModel newWeapon)
        {
            currentWeapon = newWeapon;
            fireRate = currentWeapon.fireRate;
            canFire = true;
        }

    }