using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] int itemCode;

    private Item item;

    private void Start()
    {
        item = ItemManager.Instance.GetItemInfo(itemCode);
    }

    public void AddQuickSlot()
    {
        int addSlot = -1;

        for (int i = 0; i < QuickSlot.slotItems.Count; i++)
        {
            if (QuickSlot.slotItems[i] == null)
            {
                addSlot = i;
                continue;
            }

            if (QuickSlot.slotItems[i].code == item.code)
            {
                addSlot = i;
                break;
            }
        }

        if (addSlot == -1)
        {
            Debug.Log("Äü ½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
            return;
        }


        var obj = ItemManager.Instance.GetItemScript(item.code) as StackConsumeItem;

        if (obj != null)
        {
            if(!obj.HoldCheck() && !obj.MaxCheck())
            {
                PlayerManager.Instance.QuickSlotPC.SetQuickSlot(itemCode, addSlot);
                obj.AddHold();
            }
            else if(obj.HoldCheck() && !obj.MaxCheck())
            {
                obj.AddHold();
            }
        }
        else
        {
            PlayerManager.Instance.QuickSlotPC.SetQuickSlot(itemCode, addSlot);
        }


        //Destroy(gameObject);
    }

    public void ShowInfo()
    {
        Debug.Log(item.name + "\n" + item.type + "\n" + item.description);
    }
}
