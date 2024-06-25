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
        PlayerManager.Instance.Inventory = this;

        ItemAddInventory(0, 0);
        ItemAddInventory(0, 1);
        ItemAddInventory(1, 2);
        ItemAddInventory(2, 3);
        ItemAddInventory(2, 4);
        ItemAddInventory(3, 5);
        ItemAddInventory(4, 6);
        ItemAddInventory(4, 7);
    }

    public void ItemAddInventory(int code, int slot)
    {
        GameObject newItem = Instantiate(itemPrefab, slots[slot].transform);

        newItem.GetComponent<DragObject>().ItemCode = code;

        newItem.GetComponent<Image>().sprite = ResourcesManager.Instance.Load<Sprite>(ItemManager.Instance.GetItemInfo(code).name);
    }

    public void OpenInventory()
    {

    }

    public void NameSort()
    {
        List<DragObject> nameSort = new List<DragObject>();

        for(int i = 0; i< slots.Count; i++)
        {
            if (slots[i].transform.childCount <= 0)
                continue;

            nameSort.Add(slots[i].GetComponentInChildren<DragObject>());
        }

        QuickSort(nameSort, 0, nameSort.Count - 1);

        for(int i = 0; i < nameSort.Count; i++)
        {
            nameSort[i].transform.SetParent(slots[i].transform);
            nameSort[i].transform.localPosition = Vector2.zero;
        }
    }

    public void TypeSort()
    {
        List<DragObject> consume = new List<DragObject>();
        List<DragObject> equip = new List<DragObject>();
        List<DragObject> weapon = new List<DragObject>();

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount <= 0)
                continue;

            if (ItemManager.Instance.GetItemInfo(slots[i].GetComponentInChildren<DragObject>().ItemCode).type == ItemType.Consume.ToString())
            {
                consume.Add(slots[i].GetComponentInChildren<DragObject>());
                continue;
            }

            if (ItemManager.Instance.GetItemInfo(slots[i].GetComponentInChildren<DragObject>().ItemCode).type == ItemType.Equip.ToString())
            {
                equip.Add(slots[i].GetComponentInChildren<DragObject>());
                continue;
            }

            if (ItemManager.Instance.GetItemInfo(slots[i].GetComponentInChildren<DragObject>().ItemCode).type == ItemType.Weapon.ToString())
            {
                weapon.Add(slots[i].GetComponentInChildren<DragObject>());
                continue;
            }
        }

        QuickSort(consume, 0, consume.Count - 1);
        QuickSort(equip, 0, equip.Count - 1);
        QuickSort(weapon, 0, weapon.Count - 1);

        List<DragObject> finish = new List<DragObject>();

        for(int i = 0; i < consume.Count; i++)
        {
            finish.Add(consume[i]);
        }

        for (int i = 0; i < equip.Count; i++)
        {
            finish.Add(equip[i]);
        }

        for (int i = 0; i < weapon.Count; i++)
        {
            finish.Add(weapon[i]);
        }

        for (int i = 0; i < finish.Count; i++)
        {
            finish[i].transform.SetParent(slots[i].transform);
            finish[i].transform.localPosition = Vector2.zero;
        }
    }

    private string GetName(int itemCode)
    {
        return ItemManager.Instance.GetItemInfo(itemCode).name;
    }

    private void Swap(List<DragObject> list, int first, int second)
    {
        DragObject temp = list[first];

        list[first] = list[second];

        list[second] = temp;
    }

    private bool PartitionCheck(string lower, string higher)
    {
        lower = lower.ToLower();
        higher = higher.ToLower();

        int range = lower.Length;

        if (range > higher.Length)
            range = higher.Length;

        for(int i = 0; i < range; i++)
        {
            if(lower[i] < higher[i])
            {
                return true;
            }
            else if (lower[i] != higher[i])
            {
                return false;
            }
        }

        return false;
    }

    private int Partition(List<DragObject> sort, int left, int right)
    {
        string pivot = GetName(sort[left].ItemCode);

        int low = left;
        int high = right + 1;

        do
        {
            do
            {
                low++;
            } while (low <= right && PartitionCheck(GetName(sort[low].ItemCode), pivot));

            do
            {
                high--;
            } while (high >= left && PartitionCheck(pivot, GetName(sort[high].ItemCode)));

            if (low < high)
            {
                Swap(sort, low, high);
            }

        } while (low < high);

        Swap(sort, left, high);

        return high;
    }

    private void QuickSort(List<DragObject> sort, int left, int right)
    {
        if(left < right)
        {
            int i = Partition(sort, left, right);

            QuickSort(sort, left, i - 1);
            QuickSort(sort, i + 1, right);
        }
    }
}
