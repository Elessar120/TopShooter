using UnityEngine;

namespace DefaultNamespace
{
    public class FirstWeaponController : WeaponController
    {
        public override void Fire()
        {
            base.Fire();
            Debug.Log("FirstWeaponController");
        }
    }
}