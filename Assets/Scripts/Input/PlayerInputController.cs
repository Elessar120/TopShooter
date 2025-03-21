
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private IMovementInput movementInput;
    private IFireInput fireInput;
    private TopShooterApplication topShooterApplication;
    private void Start()
    {
        topShooterApplication = FindFirstObjectByType<TopShooterApplication>();
        // Get the appropriate input components based on the current input type
        if (InputManager.Instance.currentInputType == InputType.Keyboard)
        {
            movementInput = GetComponent<KeyboardMovementInput>();
            fireInput = GetComponent<KeyboardFireInput>();
        }
        else
        {
            movementInput = GetComponent<TouchMovementInput>();
            fireInput = GetComponent<TouchFireInput>();
        }
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
        //dont move if game over
       if (!topShooterApplication.topShooterModel.isRunning)
            return; 
       fireInput?.FireInput();
    }

    private void FixedUpdate()
    {
        //dont fire if game over
        if (!topShooterApplication.topShooterModel.isRunning)
            return;
        movementInput?.HandleInput();
    }
}