using UnityEngine;

public class TouchFireInput : MonoBehaviour
{
    [SerializeField]
    private WeaponController weaponController; // Assign in inspector

    private void Start()
    {
        if (weaponController == null)
        {
            Debug.LogError("WeaponController is not assigned!");
        }
    }

    /// <summary>
    ///   Handles touch fire input.
    /// </summary>
    public void FireInput()
    {
            // Fire automatically
                weaponController.currentWeapon.Fire();
    }
}