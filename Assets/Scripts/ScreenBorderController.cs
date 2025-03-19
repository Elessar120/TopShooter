using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ScreenBorderController : MonoBehaviour
{
  [SerializeField] Camera mainCamera;
  [SerializeField] private GameObject rightborder;
  [SerializeField] private GameObject leftborder;
  private Vector3 lastCamPos;
  private Vector2 lastScreenSize;
  private Vector3 leftEdge, rightEdge, topEdge, bottomEdge;

  void Start()
  {
    if (mainCamera == null)
      mainCamera = Camera.main;
    UpdateScreenEdges();
  }
  private void LateUpdate()
  {
    // Update only if the camera moved or screen size changed
    if (mainCamera.transform.position != lastCamPos || 
        Screen.width != lastScreenSize.x || 
        Screen.height != lastScreenSize.y)
    {
      UpdateScreenEdges();
    }
   
  }

  private void UpdateScreenEdges()
  {
    lastCamPos = mainCamera.transform.position;
    lastScreenSize = new Vector2(Screen.width, Screen.height);

    leftEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, mainCamera.nearClipPlane));
    rightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, mainCamera.nearClipPlane));
    rightborder.transform.position = rightEdge;
    leftborder.transform.position = leftEdge;

    Debug.Log($"Updated Edges: Left {leftEdge}, Right {rightEdge}, Top {topEdge}, Bottom {bottomEdge}");
    
  }
}
