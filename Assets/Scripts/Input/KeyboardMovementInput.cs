using UnityEngine;

/// <summary>
///   Handles keyboard movement input.
/// </summary>
public class KeyboardMovementInput : MonoBehaviour, IMovementInput
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 5f;

    private void FixedUpdate()
    {
        HandleInput();
    }

    /// <summary>
    ///   Handles keyboard movement input.
    /// </summary>
    public void HandleInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float speed = moveSpeed; // Use local moveSpeed
        Vector3 movement = new Vector3(moveX, 0, 0f) * (speed * Time.fixedDeltaTime);

        // Example boundaries (you might want to get these from somewhere else)
        float leftBoundary = -5f;
        float rightBoundary = 5f;

        Vector3 desiredPosition = transform.position + movement;
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftBoundary, rightBoundary);

        rb.MovePosition(desiredPosition);
    }
}