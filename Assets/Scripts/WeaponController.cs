using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

    public class WeaponController : Element
    {
        private float fireRate;

        private bool GetCanFire()
        {
            return TopShooterApplication.topShooterModel.weaponModel.currentWeapon.canFire;
        }
        
        private float GetFireRate()
        {
            return TopShooterApplication.topShooterModel.weaponModel.currentWeapon.fireRate;
        }

        private void SetCanFire(bool value)
        {
            TopShooterApplication.topShooterModel.weaponModel.currentWeapon.canFire = value;
        }
        private void Update()
        {
            if (!GetCanFire())
            {
                if (fireRate > 0)
                {
                    fireRate -= Time.deltaTime;
                }
                if (fireRate <= 0)
                {
                    SetCanFire(true);
                }
               
            }
        }

        public virtual void Fire()
        {
            if (!GetCanFire())
            {
                return;
            }
            Debug.Log("Fire");
            var bullet = TopShooterApplication.topShooterModel.bulletPool.GetBullet();
            bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.transform.position;
            bullet.GetComponent<Bullet>().Activate();
            StartCoroutine(DestroyBullet(bullet));
            SetCanFire(false);
            fireRate = GetFireRate();

            //todo: add bullet function
        }
        private IEnumerator DestroyBullet(GameObject bullet)// todo: move to bullet
        {
            yield return new WaitForSeconds(TopShooterApplication.topShooterModel.bulletModel.lifeTime);
            Destroy(bullet);
        }
    }