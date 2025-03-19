using UnityEngine;

/// <summary>
///   Handles touch fire input.
/// </summary>
public class TouchFireInput : MonoBehaviour, IFireInput
{
    [SerializeField]
    private WeaponController weaponController; // Assign in inspector

    [SerializeField]
    private float fireRate = 0.5f;

    private float nextFireTime;

    private void Start()
    {
        if (weaponController == null)
        {
            Debug.LogError("WeaponController is not assigned!");
        }
        nextFireTime = Time.time;
    }
    private void FixedUpdate()
    {
        FireInput();
    }

    /// <summary>
    ///   Handles touch fire input.
    /// </summary>
    public void FireInput()
    {
        if (Input.touchCount > 0)
        {
            // Fire automatically
            if (Time.time > nextFireTime)
            {
                weaponController.currentWeapon.Fire();
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            //if you want the player to stop firing when not touching screen
            //nextFireTime = Time.time;
        }
    }
}