using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TextManager : SingletonManager<TextManager>
{
    private Dictionary<string, List<Dictionary<string, object>>> preLoadCSV = new Dictionary<string, List<Dictionary<string, object>>>();

    public string LoadString(string FileName, int LoadIndex, string loadType)
    {
        if (!preLoadCSV.ContainsKey(FileName))
        {
            preLoadCSV.Add(FileName, ResourcesManager.Instance.Read(FileName));
        }

        return preLoadCSV.GetValueOrDefault(FileName)[LoadIndex][loadType].ToString();
    }

    public Item LoadItem(int code)
    {
        Item saveItem = new Item();

        saveItem.code = code;
        saveItem.name = LoadString("ItemData", code, "Name");
        saveItem.type = LoadString("ItemData", code, "Type");
        saveItem.description = LoadString("ItemData", code, "Description");

        return saveItem;
    }

    public int GetCSVLength(string FileName)
    {
        if (!preLoadCSV.ContainsKey(FileName))
        {
            preLoadCSV.Add(FileName, ResourcesManager.Instance.Read(FileName));
        }

        return preLoadCSV.GetValueOrDefault(FileName).Count;
    }
}
