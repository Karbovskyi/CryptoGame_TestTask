using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, 
    IPointerClickHandler, 
    IPointerEnterHandler, 
    IPointerExitHandler
{
    [Header("Events")]
    public UnityEvent onClick;
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
        Debug.Log("OnPointerClick");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHoverEnter?.Invoke();
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onHoverExit?.Invoke();
        Debug.Log("OnPointerExit");
    }
}