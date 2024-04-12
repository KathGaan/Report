using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;

    [SerializeField] Transform inventory;

    [SerializeField] ItemObject itemObject;

    public ItemObject ItemObject
    {
        get { return itemObject; }
    }

    //Item

    public void GetItem()
    {
        int i = UnityEngine.Random.Range(0, itemObject.ItemList.Count);

        GameObject newItem = Instantiate(itemPrefab, inventory);

        newItem.GetComponent<ItemObj>().Info = itemObject.ItemList[i];

        newItem.GetComponent<ItemObj>().ItemImage.sprite = Resources.Load<Sprite>(newItem.GetComponent<ItemObj>().Info.name);

    }

    public void UseItem()
    {
        if(InventoryManager.selectedObject == null)
        {
            return;
        }

        var effect = itemObject.ItemScrpts[InventoryManager.selectedObject.Info.num] as IUseEffect;
        
        if(effect != null)
        {
            effect.UseEffect();

            Destroy(InventoryManager.selectedObject.gameObject);

            InventoryManager.selectedObject = null;
        }
    }

    public void EquipItem()
    {
        if (InventoryManager.selectedObject == null)
        {
            return;
        }

        var effect = itemObject.ItemScrpts[InventoryManager.selectedObject.Info.num] as IEquipEffect;

        if (effect != null)
        {
            effect.EquipEffect();

            InventoryManager.selectedObject.Select();

            InventoryManager.selectedObject = null;
        }
    }


}

[Serializable]
public class Item 
{
    public ItemType type;
    public string name;
    public int num;
}

public enum ItemType
{
    Use,
    Equip,
    None
}
