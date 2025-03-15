using System;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
public class PlayerInputController : Element
{
    Rigidbody2D rigidbody2D;
    private float LeftBoundary () => TopShooterApplication.topShooterModel.leftEdge != null
        ? TopShooterApplication.topShooterModel.leftEdge.position.x + 1f
        : throw new Exception("Left edge not found");
    private float RightBoundary () => TopShooterApplication.topShooterModel.rightEdge != null
        ? TopShooterApplication.topShooterModel.rightEdge.position.x - 1f
        : throw new Exception("right not found");
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // todo: add movement controller
            float moveX = Input.GetAxis("Horizontal");

            float speed = TopShooterApplication.topShooterModel.moveSpeed;
            Vector3 movement = new Vector3(moveX, 0, 0f) * (speed * Time.fixedDeltaTime);
        
            Vector3 desiredPosition = transform.position + movement;

            desiredPosition.x = Mathf.Clamp(desiredPosition.x, LeftBoundary(), RightBoundary());

            rigidbody2D.MovePosition(desiredPosition);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TopShooterApplication.topShooterController.weaponController.Fire();
               
            }
    }
}
