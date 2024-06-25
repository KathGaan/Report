using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (!Task())
            return;

        DragObject.dragGameObject.transform.SetParent(transform);

        DragObject.dragGameObject.transform.localPosition = Vector2.zero;
    }

    public virtual bool Task()
    {
        if (transform.childCount > 0)
            return false;
        return true;
    }
}
