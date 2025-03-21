using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] // Allows you to set the speed in the Inspector
    private float moveSpeed = 2f;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Move the enemy downwards along the Y-axis
        transform.Translate(Vector3.down * moveSpeed * Time.fixedDeltaTime);
    }
    
}