using UnityEngine;

/// <summary>
///   Handles keyboard fire input.
/// </summary>
public class KeyboardFireInput : MonoBehaviour, IFireInput
{
    [SerializeField]
    private WeaponController weaponController; 

    private void Start()
    {
        if (weaponController == null)
        {
            Debug.LogError("WeaponController is not assigned!");
        }
    }
    private void FixedUpdate()
    {
        FireInput();
    }

    /// <summary>
    ///   Handles keyboard fire input.
    /// </summary>
    public void FireInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weaponController.currentWeapon.Fire();
        }
    }
}