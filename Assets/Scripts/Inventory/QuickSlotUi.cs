using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotUi : Slot
{
    [SerializeField] int slotNum;

    public void SetSlotImage(int code)
    {
        if (code < 0)
        {
            gameObject.GetComponent<Image>().sprite = null;
            return;
        }

        gameObject.GetComponent<Image>().sprite = ResourcesManager.Instance.Load<Sprite>(ItemManager.Instance.GetItemInfo(code).name);
    }

    public void SetQuickSlot(int code)
    {
        QuickSlot.slotItems[slotNum] = ItemManager.Instance.GetItemScript(code);
        SetSlotImage(code);
    }

    public void ClearSlot()
    {
        QuickSlot.slotItems[slotNum] = null;
        SetSlotImage(-1);
    }

    public override bool Task()
    {
        int i = DragObject.dragGameObject.GetComponent<DragObject>().ItemCode;

        var task = ItemManager.Instance.GetItemScript(i) as ConsumeItem;

        if (task == null)
            return false;

        SetQuickSlot(i);

        return true;
    }

}
