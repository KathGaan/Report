using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public static List<int> slotItemCodes = new List<int>();

    [SerializeField] List<int> startItemCode;

    private List<SlotUi> slotUis;

    private void Awake()
    {
        PlayerManager.Instance.SlotMng = this;
    }

    private void OnEnable()
    {
        InputManager.Instance.keyDownAction += KeyDownAction;
    }

    private void Start()
    {
        slotUis = new List<SlotUi>();

        slotUis = FindObjectsOfType<SlotUi>().ToListPooled();

        slotItemCodes.Capacity = startItemCode.Count;

        for (int i = 0; i < startItemCode.Count; i++)
        {
            slotItemCodes.Add(startItemCode[i]);
        }

        UpdateAllSlotUi();
    }

    public void UpdateAllSlotUi()
    {
        for(int i = 0; i < slotUis.Count; i++)
        {
            if (slotItemCodes[slotUis[i].slotNum] < 0)
                continue;

            slotUis[i].SetSlot(slotItemCodes[slotUis[i].slotNum]);
        }
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
                if (slotItemCodes[i] < 0)
                    return;
                ItemManager.Instance.ActiveItem(slotItemCodes[i]);
                break;
            }

            i++;

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (slotItemCodes[i] < 0)
                    return;
                ItemManager.Instance.ActiveItem(slotItemCodes[i]);
                break;
            }

            i++;

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (slotItemCodes[i] < 0)
                    return;
                ItemManager.Instance.ActiveItem(slotItemCodes[i]);
                break;
            }

            i++;

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (slotItemCodes[i] < 0)
                    return;
                ItemManager.Instance.ActiveItem(slotItemCodes[i]);
                break;
            }

            return;
        } while (false);

        {
            var task = ItemManager.Instance.GetItemScript(slotItemCodes[i]) as ConsumeItem;

            if (task != null && task.usedSuccess)
            {
                task.UsedSuccess(slotUis[i]);
            }
        }

        {
            var task = ItemManager.Instance.GetItemScript(slotItemCodes[i]) as CoolDownItem;

            if (task != null && task.canUse)
            {
                task.UsedSuccess(slotUis[i]);
            }
        }

        {
            var task = ItemManager.Instance.GetItemScript(slotItemCodes[i]) as StackConsumeItem;

            if (task != null)
            {
                slotUis[i].SetSlotInfo(task.code);
            }
        }
    }

    public void SetUpdateSlot(int code, int slot)
    {
        if (slot < 0)
            return;

        for(int i = 0; i < slotUis.Count; i++)
        {
            if (slotUis[i].slotNum != slot)
                continue;

            if (code < 0)
            {
                if (slotUis[i].gameObject.transform.childCount <= 0)
                    continue;

                slotUis[i].ClearSlot();
                continue;
            }

            slotUis[i].SetSlot(code);
        }

    }
}
