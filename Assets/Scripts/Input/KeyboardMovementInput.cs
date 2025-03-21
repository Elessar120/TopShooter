using UnityEngine;

public class KeyboardMovementInput : Element, IMovementInput
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 5f;

    private void FixedUpdate()
    {
        HandleInput();
    }
    
    public void HandleInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float speed = moveSpeed; // Use local moveSpeed
        Vector3 movement = new Vector3(moveX, 0, 0f) * (speed * Time.fixedDeltaTime);

        float leftBoundary = TopShooterApplication.topShooterModel.leftEdge.position.x + 1f;
        float rightBoundary = TopShooterApplication.topShooterModel.rightEdge.position.x - 1f;;

        Vector3 desiredPosition = transform.position + movement;
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftBoundary, rightBoundary);

        rb.MovePosition(desiredPosition);
    }
}