using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotUi : Slot
{
    [SerializeField] int slotNum;

    public void SetSlotInfo(int code)
    {
        if (code < 0)
        {
            gameObject.GetComponent<Image>().sprite = null;

            SetCountText(-1);
            return;
        }

        gameObject.GetComponent<Image>().sprite = ResourcesManager.Instance.Load<Sprite>(ItemManager.Instance.GetItemInfo(code).name);


        var consume = ItemManager.Instance.GetItemScript(code) as StackConsumeItem;

        if(consume != null)
        {
            SetCountText(consume.GetHoldNum());
        }
    }

    public void SetQuickSlot(int code)
    {
        QuickSlot.slotItems[slotNum] = ItemManager.Instance.GetItemScript(code);
        SetSlotInfo(code);
    }

    public void ClearSlot()
    {
        QuickSlot.slotItems[slotNum] = null;
        SetSlotInfo(-1);
    }

    public void CoolDownStart(CoolDownItem obj)
    {
        gameObject.GetComponent<Image>().material = PlayerManager.Instance.GrayShader;

        StartCoroutine(CoolDown(obj));
    }

    private IEnumerator CoolDown(CoolDownItem obj)
    {
        float coolTime = obj.coolDown;

        while (coolTime > 0f)
        {
            coolTime -= Time.deltaTime;

            SetCountText((int)coolTime + 1);

            yield return null;

        }

        SetCountText(-1);

        obj.canUse = true;

        gameObject.GetComponent<Image>().material = null;
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
