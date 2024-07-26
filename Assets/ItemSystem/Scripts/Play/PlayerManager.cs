using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingletonManager<PlayerManager>
{
    private SlotManager slotMng;

    public SlotManager SlotMng 
    { 
        get { return slotMng; }
        set { slotMng = value; }
    }

    private InventoryManager inventory;

    public InventoryManager Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }

    [SerializeField] Material grayShder;

    public Material GrayShader
    {
        get { return grayShder; }
    }

    public void ChangeLanguage(string language)
    {
        DataManager.Instance.Data.Language = language;
    }
}
