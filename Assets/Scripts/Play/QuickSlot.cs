using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    public static List<ConsumeItem> slotItems;

    private void Awake()
    {
        slotItems = new List<ConsumeItem>() {null,null,null };
    }

    private void Start()
    {
        PlayManager.Instance.SetQuickSlot(0,0);

        InputManager.Instance.keyDownAction += KeyDownAction;
    }

    private void OnDisable()
    {
        InputManager.Instance.keyDownAction -= KeyDownAction;
    }

    public void KeyDownAction()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ItemManager.Instance.ActiveItem(slotItems[0].code);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            ItemManager.Instance.ActiveItem(slotItems[1].code);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            ItemManager.Instance.ActiveItem(slotItems[2].code);
    }
}
