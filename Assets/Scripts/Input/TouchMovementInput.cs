using UnityEngine;
using UnityEngine.EventSystems;

public class TouchMovementInput : Element
{
    private float deltaX, deltaY;
    private Camera mainCamera;
    private Vector2 targetPosition;
    private bool shouldMove;

    // Boundary variables
    private float leftEdge;
    private float rightEdge;
    private float bottomEdge;
    private float topEdge;

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found! Make sure your camera is tagged 'MainCamera'.", gameObject);
        }

        shouldMove = false;

        // Initialize boundary values
        leftEdge = TopShooterApplication.topShooterModel.leftEdge.position.x + 1;
        rightEdge = TopShooterApplication.topShooterModel.rightEdge.position.x - 1;
        bottomEdge = TopShooterApplication.topShooterModel.buttonEdge.position.y + 2f;
        topEdge = TopShooterApplication.topShooterModel.topEdge.position.y - 2;
    }

    private void Update()
    {
        HandleInput();

        if (shouldMove)
        {
            // Move the spaceship using MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 30 * Time.deltaTime);

            // Clamp the player's position *after* moving
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, leftEdge, rightEdge),
                Mathf.Clamp(transform.position.y, bottomEdge, topEdge),
                transform.position.z
            );

            Debug.Log($"Moving to {targetPosition}, Actual Position: {transform.position}");
        }
    }

    private void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPositionWithDepth = new Vector3(touch.position.x, touch.position.y, -mainCamera.transform.position.z);
            Vector2 touchPosition = mainCamera.ScreenToWorldPoint(touchPositionWithDepth);

            if (touch.phase == TouchPhase.Began)
            {
                deltaX = touchPosition.x - transform.position.x;
                deltaY = touchPosition.y - transform.position.y;
                Debug.Log($"Touch Began - Delta: ({deltaX}, {deltaY})");
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Check if the touch is over a UI element
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    // Touch is over a UI element, so ignore it for ship movement
                    shouldMove = false;
                    return;
                }

                targetPosition = new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY);
                shouldMove = true;
                Debug.Log($"Touch Position: {touchPosition}, Target Position: {targetPosition}, Delta: ({deltaX}, {deltaY})");
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                shouldMove = false;
                Debug.Log("Touch Ended");
            }
        }
        else
        {
            shouldMove = false;
        }
    }
}