using System;
using UnityEngine;

    public class TopShooterModel : Element
    {
        public float moveSpeed = 5f;
        public Transform rightEdge;
        public Transform leftEdge;
        public BulletPool bulletPool;
        public Transform bulletSpawnPoint;
        public BulletModel bulletModel;

        private void Start()
        {
            if (bulletPool == null)
            {
                bulletPool = FindFirstObjectByType<BulletPool>();
            }
        }
    }
