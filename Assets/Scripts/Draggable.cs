using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;
    [SerializeField]
    private float dragDelay = 0.5f;
    private float pointerDownTime;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("DraggableButton must be a child of a Canvas.", gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDownTime = Time.time;
        isDragging = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging && Time.time - pointerDownTime < dragDelay)
        {
            return;
        }

        isDragging = true;

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            eventData.position,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out localPointerPosition))
        {
            rectTransform.localPosition += (Vector3)localPointerPosition - (Vector3)rectTransform.localPosition;

            KeepInBounds();
        }
    }

    private void KeepInBounds()
    {
        if (canvas == null || rectTransform == null) return;

        Vector3 pos = rectTransform.localPosition;
        Vector3 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
        Vector3 buttonSize = rectTransform.sizeDelta * rectTransform.localScale;

        float minX = -canvasSize.x / 2f + buttonSize.x / 2f;
        float maxX = canvasSize.x / 2f - buttonSize.x / 2f;
        float minY = -canvasSize.y / 2f + buttonSize.y / 2f;
        float maxY = canvasSize.y / 2f - buttonSize.y / 2f;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        rectTransform.localPosition = pos;
    }
}