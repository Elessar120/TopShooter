using UnityEngine;

/// <summary>
///   Handles touch movement input.
/// </summary>
public class TouchMovementInput : MonoBehaviour, IMovementInput
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 5f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    /// <summary>
    ///   Handles touch movement input.
    /// </summary>
    public void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);

            // Move the player
            Vector2 movement = (Vector2)transform.position - touchPosition;
            movement.x *= -1;
            movement = movement.normalized;
            float speed = moveSpeed; // Use local moveSpeed
            Vector3 move = new Vector3(movement.x, 0, 0f) * (speed * Time.deltaTime);

            // Example boundaries (you might want to get these from somewhere else)
            float leftBoundary = -5f;
            float rightBoundary = 5f;

            Vector3 desiredPosition = transform.position + move;
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftBoundary, rightBoundary);
            rb.MovePosition(desiredPosition);
        }
    }
}