using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
[System.Serializable]
public class JoyStickEvent : UnityEvent<Vector3> { }
public class FixJoyStick : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Transform content;
    public UnityEvent beginEvent;
    public JoyStickEvent controlling;
    public UnityEvent endEvent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.beginEvent.Invoke();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (this.content)
        {
            this.controlling.Invoke(this.content.localPosition.normalized);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        this.endEvent.Invoke();
    }

}
