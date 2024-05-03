using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoSingletonManager<PlayManager>
{
    private EquipItem equipItem;

    [SerializeField] Image image;

    private void Start()
    {
        equipItem = new EquipItem();   
    }

    public void ClearEquip()
    {
        EquipItem.equipItemScript = null;
        image.sprite = null;
    }

    public void TestEquip()
    {
        Debug.Log("Protect를 장착 했습니다.");

        ItemManager.Instance.SetEquip(ItemManager.Instance.GetItem(1));

        image.sprite = ResourcesManager.Instance.Load<Sprite>(ItemManager.Instance.GetItem(1).name);
    }

    public void TestHit()
    {
        equipItem.OnHit();
    }
}
