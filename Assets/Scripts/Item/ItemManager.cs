using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;

public class ItemManager : SingletonManager<ItemManager>
{
    private Dictionary<int, Item> itemScripts;

    private List<Item> items;

    public ItemManager()
    {
        itemScripts = new Dictionary<int, Item>();

        LoadItems();
    }

    private void LoadItems()
    {
        items = new List<Item>();

        for(int i = 0; i < TextManager.Instance.GetCSVLength("ItemData"); i++)
        {
            items.Add(LoadItem(i));
        }
    }

    public Item LoadItem(int code)
    {
        Item saveItem = new Item();

        saveItem.code = code;
        saveItem.name = TextManager.Instance.LoadString("ItemData", code, "Name");
        saveItem.type = TextManager.Instance.LoadString("ItemData", code, "Type");
        saveItem.description = TextManager.Instance.LoadString("ItemData", code, "Description");

        return saveItem;
    }

    private void AddItemScript(int code)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            Type[] types = assembly.GetTypes();

            foreach (var type in types.Where(t => t.IsSubclassOf(typeof(Item))))
            {
                if (type.Name == items[code].name)
                {
                    itemScripts.Add(code, (Item)Activator.CreateInstance(type));
                }
            }
        }
    }

    public Item GetItemScript(int code)
    {
        if (!itemScripts.ContainsKey(code))
            AddItemScript(code);

        return itemScripts.GetValueOrDefault(code);
    }

    public Item GetItemInfo(int code)
    {
        return items[code];
    }

    public void SetEquip(int code)
    {
        PlayManager.equipItemScript = GetItemScript(code);
    }


    public void ActiveItem(int code)
    {
        var function = GetItemScript(code) as IConsumeSpell;

        if(function != null)
        {
            function.SpellEffect();
        }


        //...
    }
}
