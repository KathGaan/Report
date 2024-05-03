using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    [SerializeField] List<Image> itemImage;

    private List<Item> slotItems;

    private void Awake()
    {
        slotItems = new List<Item>() {null,null,null };
    }

    private void Start()
    {
        //Test
        SetSlotItem(0, 0);

        InputManager.Instance.keyDownAction += KeyDownAction;
    }

    private void OnDisable()
    {
        InputManager.Instance.keyDownAction -= KeyDownAction;
    }

    public void SetSlotItem(int code, int slotNum)
    {
        slotItems[slotNum] = ItemManager.Instance.GetItem(code);
        itemImage[slotNum].sprite = ResourcesManager.Instance.Load<Sprite>(slotItems[slotNum].name);
    }

    public void SetSlotItem(Item item, int slotNum)
    {
        slotItems[slotNum] = item;
        itemImage[slotNum].sprite = ResourcesManager.Instance.Load<Sprite>(slotItems[slotNum].name);
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
