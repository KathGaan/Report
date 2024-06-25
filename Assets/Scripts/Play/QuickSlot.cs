using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    public static List<Item> slotItems;

    [SerializeField] List<int> startItemCode;

    [SerializeField] List<QuickSlotUi> quickSlotUis;

    private void Awake()
    {
        PlayerManager.Instance.QuickSlotPC = this;

        slotItems = new List<Item>() {null, null, null, null };

        for(int i = 0; i < startItemCode.Count; i++)
        {
            quickSlotUis[i].SetQuickSlot(startItemCode[i]);
        }
    }

    private void Start()
    {
        InputManager.Instance.keyDownAction += KeyDownAction;
    }

    private void OnDisable()
    {
        InputManager.Instance.keyDownAction -= KeyDownAction;
    }

    public void KeyDownAction()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (slotItems[0] == null)
                return;
            ItemManager.Instance.ActiveItem(slotItems[0].code);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (slotItems[1] == null)
                return;
            ItemManager.Instance.ActiveItem(slotItems[1].code);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (slotItems[2] == null)
                return;
            ItemManager.Instance.ActiveItem(slotItems[2].code);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (slotItems[3] == null)
                return;
            ItemManager.Instance.ActiveItem(slotItems[3].code);
        }
    }

    public void SetQuickSlot(int code, int slot)
    {
        quickSlotUis[slot].SetQuickSlot(code);
    }
}
