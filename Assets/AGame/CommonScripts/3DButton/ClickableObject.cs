using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, 
    IPointerClickHandler
{
    [Header("Events")]
    public UnityEvent onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
        Debug.Log("OnPointerClick");
    }
}