using UnityEngine;
using UnityEngine.Serialization;

public class TopShooterView : Element
    {
        public PlayerView playerPrefab;
        [FormerlySerializedAs("weaponBox")] [FormerlySerializedAs("newWeapon")] public WeaponView weaponView;
    }