using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUi : Slot
{
    public int slotNum;

    public void SetSlotInfo(int code)
    {
        if (code < 0)
        {
            Destroy(transform.GetChild(0).gameObject);
            return;
        }

        var consume = ItemManager.Instance.GetItemScript(code) as StackConsumeItem;

        if(consume != null)
        {
            SetCountText(transform.GetComponentInChildren<TextMeshProUGUI>() , consume.GetHoldNum());
        }
        else
        {
            SetCountText(transform.GetComponentInChildren<TextMeshProUGUI>(), -1);
        }
    }

    private void ChangeSlotItem(int code)
    {
        transform.GetComponentInChildren<DragObject>().ItemCode = code;

        transform.GetComponentInChildren<DragObject>().GetComponent<Image>().sprite = ResourcesManager.Instance.Load<Sprite>(ItemManager.Instance.GetItemInfo(code).name);
    }

    public void SetSlot(int code)
    {
        if (transform.childCount > 0)
        {
            ChangeSlotItem(code);
            SetSlotInfo(code);
            return;
        }

        PlayerManager.Instance.Inventory.ItemCreate(code, transform);

        SetSlotInfo(code);
    }

    public void ClearSlot()
    {
        SlotManager.slotItemCodes[slotNum] = -1;
        SetSlotInfo(-1);
    }

    public void CoolDownStart(CoolDownItem obj)
    {
        transform.GetChild(0).GetComponentInChildren<Image>().material = PlayerManager.Instance.GrayShader;

        StartCoroutine(CoolDown(obj));
    }

    private IEnumerator CoolDown(CoolDownItem obj)
    {
        float coolTime = obj.coolDown;

        while (coolTime > 0f)
        {
            coolTime -= Time.deltaTime;

            SetCountText(transform.GetComponentInChildren<TextMeshProUGUI>(), (int)coolTime + 1);

            yield return null;

        }

        SetCountText(transform.GetComponentInChildren<TextMeshProUGUI>(), - 1);

        obj.canUse = true;

        transform.GetChild(0).GetComponentInChildren<Image>().material = null;
    }

    public override bool Task()
    {
        int i = DragObject.dragGameObject.GetComponent<DragObject>().ItemCode;

        if (transform.childCount > 0)
        {
            int j = gameObject.GetComponentInChildren<DragObject>().ItemCode;

            SwapItem(transform.childCount);
            
            PlayerManager.Instance.SlotMng.SetUpdateSlot(j, DragObject.dragGameObject.GetComponent<DragObject>().GetParentSlotNum());

            DragObject.dragGameObject.transform.SetParent(transform);
            DragObject.dragGameObject.transform.localPosition = Vector2.zero;

            PlayerManager.Instance.SlotMng.SetUpdateSlot(i, slotNum);

            return false;
        }
        else
        {
            PlayerManager.Instance.SlotMng.SetUpdateSlot(-1, DragObject.dragGameObject.GetComponent<DragObject>().GetParentSlotNum());
        }

        PlayerManager.Instance.SlotMng.SetUpdateSlot(i, slotNum);

        return true;
    }

}
