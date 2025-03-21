using UnityEngine;

public class TouchFireInput : MonoBehaviour, IFireInput
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
    private void Update()
    {
        FireInput();
    }

    /// <summary>
    ///   Handles touch fire input.
    /// </summary>
    public void FireInput()
    {
        if (Input.touchCount > 1)
        {
            // Fire automatically
                weaponController.currentWeapon.Fire();
        }
    }
}