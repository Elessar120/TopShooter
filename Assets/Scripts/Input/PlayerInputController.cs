using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   Handles player input for movement and firing.
/// </summary>
public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private IMovementInput movementInput;
    private IFireInput fireInput;

    private void Start()
    {
        // Dependency Inversion: Using interfaces
        movementInput = GetComponent<IMovementInput>();
        fireInput = GetComponent<IFireInput>();

        if (movementInput == null)
        {
            Debug.LogError("No IMovementInput component found on the player!");
        }

        if (fireInput == null)
        {
            Debug.LogError("No IFireInput component found on the player!");
        }
    }

    private void Update()
    {
        // Delegate input handling to the appropriate components
        movementInput?.HandleInput();
        fireInput?.FireInput();
    }
}