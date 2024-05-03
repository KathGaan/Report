using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;

public class ItemDictionary
{
    private Dictionary<int, ItemObj> itemScripts;

    public ItemDictionary()
    {
        itemScripts = new Dictionary<int, ItemObj>();
    }

    private void AddItemScript(int code)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach(var assembly in assemblies)
        {
            Type[] types = assembly.GetTypes();

            foreach (var type in types.Where(t => t.IsSubclassOf(typeof(ItemObj))))
            {
                if (type.Name == "Item_" + code)
                {
                    itemScripts.Add(code, (ItemObj)Activator.CreateInstance(type));
                }
            }
        }
    }

    public ItemObj GetItemObj(int code)
    {
        if (!itemScripts.ContainsKey(code))
            AddItemScript(code);

        return itemScripts.GetValueOrDefault(code);
    }
}
