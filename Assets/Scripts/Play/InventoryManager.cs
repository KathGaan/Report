using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System;
using System.Linq;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Transform slotParent;

    private List<Slot> slots;

    [SerializeField] GameObject itemPrefab;

    CultureInfo koreanCulture;

    [SerializeField] TMP_InputField searchField;

    private void Start()
    {
        PlayerManager.Instance.Inventory = this;

        koreanCulture = new CultureInfo("ko-KR");

        slots = new List<Slot>();

        for(int i = 0; i < slotParent.childCount; i++)
        {
            slots.Capacity = slotParent.childCount;

            slots.Add(slotParent.GetChild(i).GetComponent<Slot>());
        }

        ItemAddInventory(0, 0);
        ItemAddInventory(0, 1);
        ItemAddInventory(1, 2);
        ItemAddInventory(2, 3);
        ItemAddInventory(2, 4);
        ItemAddInventory(3, 5);
        ItemAddInventory(4, 6);
        ItemAddInventory(4, 7);
        ItemAddInventory(5, 8);
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

    public void InputValueChanged()
    {
        SearchItem(searchField.text);
    }

    private void SearchItem(string str)
    {

        for(int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount <= 0)
                continue;

            if (!TextManager.Instance.LoadString("ItemLanguage", slots[i].GetComponentInChildren<DragObject>().ItemCode).Contains(str, StringComparison.OrdinalIgnoreCase))
            {
                slots[i].GetComponentInChildren<Image>().material = PlayerManager.Instance.GrayShader;
            }
            else
            {
                slots[i].GetComponentInChildren<Image>().material = null;
            }
        }
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
        List<List<DragObject>> sort = new List<List<DragObject>>();

        for (int i = 0; i < (int)ItemType.Count; i++)
        {
            sort.Add(new List<DragObject>());
        }

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount <= 0)
                continue;

            for(int j = 0; j < (int)ItemType.Count; j++)
            {
                if (ItemManager.Instance.GetItemInfo(slots[i].GetComponentInChildren<DragObject>().ItemCode).type == ((ItemType)j).ToString())
                {
                    sort[j].Add(slots[i].GetComponentInChildren<DragObject>());
                    break;
                }
            }

        }

        for (int i = 0; i < sort.Count; i++)
        {
            if (sort[i].Count <= 1)
                continue;

            QuickSort(sort[i], 0, sort[i].Count - 1);
        }

        List<DragObject> finish = new List<DragObject>();

        for (int i = 0; i < sort.Count; i++)
        {
            for (int j = 0; j < sort[i].Count; j++)
            {
                finish.Add(sort[i][j]);
            }
        }

        for (int i = 0; i < finish.Count; i++)
        {
            finish[i].transform.SetParent(slots[i].transform);
            finish[i].transform.localPosition = Vector2.zero;
        }
    }

    private string GetName(int itemCode)
    {
        return TextManager.Instance.LoadString("ItemLanguage",itemCode);
    }

    private void Swap(List<DragObject> list, int first, int second)
    {
        DragObject temp = list[first];

        list[first] = list[second];

        list[second] = temp;
    }

    private bool PartitionCheck(string lower, string higher)
    {
        int compareResult = 0;

        if(DataManager.Instance.Data.Language == "Korean")
        {
            compareResult = String.Compare(lower, higher, false, koreanCulture);
        }
        else if(DataManager.Instance.Data.Language == "English")
        {
            compareResult = String.Compare(lower, higher, false);
        }

        if(compareResult < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
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
