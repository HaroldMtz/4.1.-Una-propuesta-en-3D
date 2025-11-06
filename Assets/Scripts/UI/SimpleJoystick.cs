using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform background;   
    public RectTransform handle;       
    public float handleLimit = 80f;    
    public Vector2 Direction { get; private set; } 

    Vector2 _centerLocal;  

    void Awake()
    {
        if (!background) background = GetComponent<RectTransform>();
        _centerLocal = Vector2.zero;           
        ResetHandle();
    }

    public void OnPointerDown(PointerEventData e) => OnDrag(e);

    public void OnDrag(PointerEventData e)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background, e.position, e.pressEventCamera, out localPoint);

        Vector2 delta = localPoint - _centerLocal;

        delta = Vector2.ClampMagnitude(delta, handleLimit);

        handle.anchoredPosition = delta;

        Direction = delta / Mathf.Max(1f, handleLimit);
    }

    public void OnPointerUp(PointerEventData e)
    {
        Direction = Vector2.zero;
        ResetHandle();
    }

    void ResetHandle()
    {
        if (handle) handle.anchoredPosition = Vector2.zero;
    }
}
