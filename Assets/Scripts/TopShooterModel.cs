using UnityEngine;
public class TopShooterModel : Element
    {
        public float moveSpeed = 5f;
        public Transform rightEdge;
        public Transform leftEdge;
        public Transform topEdge;
        public Transform buttonEdge;
        public Pool simpleBullet;
        public Pool explosiveBullet;
        public Pool enemy1;
        public Pool enemy2;
        public Pool enemy3;
        public Transform bulletSpawnPoint;
        public BulletModel bulletModel;
        public WeaponModel weaponModel;
        public WeaponModel firstWeaponModel;
        public WeaponModel secondWeaponModel;
        public WeaponModel thirdWeaponModel;
        public bool isRunning = true;
    }
