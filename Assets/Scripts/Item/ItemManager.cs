using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoSingletonManager<ItemManager>
{
    private ItemDictionary itemDictionary;

    private Dictionary<int, Item> items;

    private void Start()
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

    public void ActiveItem(int code)
    {
        ItemObj activeObj = itemDictionary.GetItemObj(code, out activeObj);

        var function = activeObj as IPotion;

        if(function != null)
        {
            function.PotionEffect();
        }


        //...
    }
}
