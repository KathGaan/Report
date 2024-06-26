using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    public static List<Item> slotItems;

    [SerializeField] List<int> startItemCode;

    [SerializeField] List<QuickSlotUi> quickSlotUis;

    private void Start()
    {
        PlayerManager.Instance.QuickSlotPC = this;

        slotItems = new List<Item>();

        slotItems.Capacity = startItemCode.Count;

        for(int i = 0; i < startItemCode.Count; i++)
        {
            slotItems.Add(null);
            quickSlotUis[i].SetQuickSlot(startItemCode[i]);
        }

        InputManager.Instance.keyDownAction += KeyDownAction;
    }

    private void OnDisable()
    {
        InputManager.Instance.keyDownAction -= KeyDownAction;
    }

    public void KeyDownAction()
    {
        int i = 0;
        do
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (slotItems[i] == null)
                    return;
                ItemManager.Instance.ActiveItem(slotItems[i].code);
                break;
            }

            i++;

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (slotItems[i] == null)
                    return;
                ItemManager.Instance.ActiveItem(slotItems[i].code);
                break;
            }

            i++;

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (slotItems[i] == null)
                    return;
                ItemManager.Instance.ActiveItem(slotItems[i].code);
                break;
            }

            i++;

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (slotItems[i] == null)
                    return;
                ItemManager.Instance.ActiveItem(slotItems[i].code);
                break;
            }

            return;
        } while (false);

        {
            var task = slotItems[i] as ConsumeItem;

            if (task != null && task.usedSuccess)
            {
                task.UsedSuccess(quickSlotUis[i]);
            }
        }

        {
            var task = slotItems[i] as CoolDownItem;

            if (task != null && task.canUse)
            {
                task.UsedSuccess(quickSlotUis[i]);
            }
        }

        {
            var task = slotItems[i] as StackConsumeItem;

            if (task != null)
            {
                quickSlotUis[i].SetSlotInfo(task.code);
            }
        }
    }

    public void SetQuickSlot(int code, int slot)
    {
        quickSlotUis[slot].SetQuickSlot(code);
    }
}
