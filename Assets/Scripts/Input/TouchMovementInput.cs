using System;
using UnityEngine;

/// <summary>
///   Handles touch movement input.
/// </summary>
public class TouchMovementInput : Element, IMovementInput
{
    [SerializeField]
    private Rigidbody2D rb;

    private bool isDragging;
    private Vector2 offset;
private Touch touch;
    [SerializeField]
    private float moveSpeed = 5f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        HandleInput();
    }

    /// <summary>
    ///   Handles touch movement input.
    /// </summary>
    public void HandleInput()
    {
        Debug.Log("TouchMovementInput");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // screen has been touched, store the touch

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }

            if (isDragging)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 _dir = new Vector2(touchPosition.x, rb.transform.position.y); // Use touchPosition.y

                rb.transform.position = Vector2.Lerp(rb.transform.position, _dir, Time.deltaTime * 10);
            }
        }
        else{
            isDragging = false;
        }
    }
    
}