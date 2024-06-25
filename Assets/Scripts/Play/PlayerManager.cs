using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingletonManager<PlayerManager>
{
    private QuickSlot quickSlotPC;

    public QuickSlot QuickSlotPC 
    { 
        get { return quickSlotPC; }
        set { quickSlotPC = value; }
    }

    private InventoryManager inventory;

    public InventoryManager Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }
}
