using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : SingletonManager<ItemManager>
{
    private ItemDictionary itemDictionary;

    private Dictionary<int, Item> items;

    public ItemManager()
    {
        itemDictionary = new ItemDictionary();

        items = new Dictionary<int, Item>();

        LoadItems();
    }

    private void LoadItems()
    {
        for(int i = 0; i < TextManager.Instance.GetCSVLength("ItemData"); i++)
        {
            items.Add(i, TextManager.Instance.LoadItem(i));
        }
    }

    public Item GetItem(int code)
    {
        return items[code];
    }

    public void SetEquip(Item item)
    {
        EquipItem.equipItemScript = itemDictionary.GetItemObj(item.code);
    }

    public void ActiveItem(int code)
    {
        var function = itemDictionary.GetItemObj(code) as IUse;

        if(function != null)
        {
            function.UseEffect();
        }


        //...
    }
}
