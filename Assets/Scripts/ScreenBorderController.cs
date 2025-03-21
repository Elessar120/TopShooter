using UnityEngine;
/// <summary>
/// ensure screen borders be in screen edges 
/// </summary>
public class ScreenBorderController : Element
{
  [SerializeField] Camera mainCamera;
  private Transform rightborder;
  private Transform leftborder;
  private Transform topborder;
  private Vector3 lastCamPos;
  private Vector2 lastScreenSize;
  private Vector3 leftEdge, rightEdge, topEdge;

  private void Awake()
  {
    if (mainCamera == null)
      mainCamera = Camera.main;
    rightborder = TopShooterApplication.topShooterModel.rightEdge;
    leftborder = TopShooterApplication.topShooterModel.leftEdge;
    topborder = TopShooterApplication.topShooterModel.topEdge;
  }

  void Start()
  {
    UpdateScreenEdges();
  }
  private void LateUpdate()
  {
    // Update only if the camera moved or screen size changed
    if (mainCamera.transform.position != lastCamPos || 
        !Mathf.Approximately(Screen.width, lastScreenSize.x) || 
        !Mathf.Approximately(Screen.height, lastScreenSize.y))
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
    topEdge = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1f, mainCamera.nearClipPlane)) - new Vector3(0, -1, 0);
    rightborder.transform.position = rightEdge;
    leftborder.transform.position = leftEdge;
    topborder.transform.position = topEdge;
  }
}
