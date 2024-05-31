using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] List<Slot> slots;

    [SerializeField] GameObject itemPrefab;

    private void Start()
    {
        ItemAddInventory(0, 0);
        ItemAddInventory(1, 4);
    }

    public void ItemAddInventory(int code, int slot)
    {
        GameObject newItem = Instantiate(itemPrefab, slots[slot].transform);

        newItem.GetComponent<DragObject>().ItemCode = code;

        newItem.GetComponent<Image>().sprite = ResourcesManager.Instance.Load<Sprite>(ItemManager.Instance.GetItemInfo(code).name);
    }

    public void OpenConsumeInventory()
    {

    }

    public void OpenEquipInventory()
    {

    }
}
