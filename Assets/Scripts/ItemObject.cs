using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList",menuName = "ItemList",order = 1)]
public class ItemObject : ScriptableObject
{
    [SerializeField] List<Item> itemList;

    public List<Item> ItemList
    {
        get { return itemList; }
    }

    [SerializeField] List<ItemScrpt> itemScrpts;

    public List<ItemScrpt> ItemScrpts
    {
        get { return itemScrpts; }
    }
}
