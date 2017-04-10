using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillImageFollow : MonoBehaviour , IBeginDragHandler,IEndDragHandler,IDragHandler{

    private Vector3 pos;

    private RectTransform rec;

    void Start()
    {
        rec = GetComponent<RectTransform>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        SetPosition(eventData);
    }



    public void OnDrag(PointerEventData eventData)
    {
        SetPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SetPosition(eventData);
        StartCoroutine(DestroySelf());
    }

    void SetPosition(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rec, Input.mousePosition, eventData.enterEventCamera, out pos))
            {
                rec.position = pos;
            }
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForEndOfFrame();
        GameController.getInstance().RayCheck(gameObject.name);
        yield return new WaitForSeconds(0.1f);
        GameManager.instance.hasChooseSkillImage = false;
        Destroy(gameObject);
    }
}
