using UnityEngine;

public class PlayerInputController : Element
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TopShooterApplication.topShooterController.weaponController.currentWeapon.Fire();
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float speed = TopShooterApplication.topShooterModel.moveSpeed;
        Vector3 movement = new Vector3(moveX, 0, 0f) * (speed * Time.fixedDeltaTime);

        float leftBoundary = TopShooterApplication.topShooterModel.leftEdge.position.x + 1f;
        float rightBoundary = TopShooterApplication.topShooterModel.rightEdge.position.x - 1f;

        Vector3 desiredPosition = transform.position + movement;
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftBoundary, rightBoundary);

        rb.MovePosition(desiredPosition);
    }
}