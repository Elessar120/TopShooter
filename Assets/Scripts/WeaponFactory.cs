using UnityEngine;

public class WeaponFactory : MonoBehaviour, IWeaponFactory
{
    public WeaponModel[] weaponModels; // Assign ScriptableObjects in the Inspector

    public WeaponModel CreateWeapon(WeaponType type)
    {
        WeaponModel newModel = null;
        foreach (var model in weaponModels)
        {
            if (model.weaponType == type)
            {
                newModel = model;
                break; // Stop at the first match
            }
        }

        if (newModel != null)
        {
            var model = FindFirstObjectByType<WeaponModel>();
            model.Magazine = newModel.Magazine;
            model.FireRate = newModel.FireRate;
            model.heatPerShot = newModel.heatPerShot;
            model.coolingRate = newModel.coolingRate;
            model.weaponType = newModel.weaponType;
            model.bulletType = newModel.bulletType;
            model.damage = newModel.damage;
            model.explosionForce = newModel.explosionForce;
            model.explosionRadius = newModel.explosionRadius;
            model.affectedLayers = newModel.affectedLayers;
            return model;
        }
        else
        {
            return null;
        }
     
    }
}