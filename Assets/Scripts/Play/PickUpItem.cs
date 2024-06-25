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
        for (int i = 0; i < QuickSlot.slotItems.Count; i++)
        {
            if (QuickSlot.slotItems[i] == null)
            {
                PlayerManager.Instance.QuickSlotPC.SetQuickSlot(itemCode, i);
                break;
            }

            if(i == QuickSlot.slotItems.Count - 1)
            {
                Debug.Log("Äü ½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
                return;
            }
        }

        Destroy(gameObject);
    }

    public void ShowInfo()
    {
        Debug.Log(item.name + "\n" + item.type + "\n" + item.description);
    }
}
