using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    [SerializeField] TextMeshProUGUI countText;

    public void SetCountText(int num)
    {
        if (countText == null)
            return;

        if (num == -1)
        {
            countText.text = null;
            return;
        }

        countText.text = num.ToString();
    }

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
