using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ScrollCircle : ScrollRect
{
    protected float radius;
    protected override void Start()
    {
        this.radius = ((RectTransform)transform).sizeDelta.x * 0.5f;
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        base.content.anchoredPosition = Vector3.ClampMagnitude(base.content.anchoredPosition, this.radius);
    }
}
