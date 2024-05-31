using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject dragGameObject;

    private Transform startSlot;

    private Transform moveTransform;

    private int itemCode;

    public int ItemCode
    {
        set { itemCode = value; }
        get { return itemCode; }
    }

    private void Start()
    {
        startSlot = transform.parent;

        moveTransform = startSlot.GetComponent<Transform>().parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragGameObject = gameObject;

        dragGameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

        startSlot = transform.parent;

        dragGameObject.transform.SetParent(moveTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragGameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragGameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

        dragGameObject = null;

        if(transform.parent == moveTransform)
        {
            transform.SetParent(startSlot);

            transform.localPosition = Vector2.zero;
        }
    }
}
