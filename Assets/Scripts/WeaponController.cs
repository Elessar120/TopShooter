using System.Collections;
using UnityEngine;

    public class WeaponController : Element
    {
        public virtual void Fire()
        {
            var bullet = TopShooterApplication.topShooterModel.bulletPool.GetBullet();
            bullet.transform.position = TopShooterApplication.topShooterModel.bulletSpawnPoint.transform.position;
            bullet.GetComponent<Bullet>().Activate();
            StartCoroutine(DestroyBullet(bullet));
            //todo: add bullet function
        }
        private IEnumerator DestroyBullet(GameObject bullet)
        {
            yield return new WaitForSeconds(TopShooterApplication.topShooterModel.bulletModel.lifeTime);
            Destroy(bullet);
        }
    }