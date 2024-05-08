using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoSingletonManager<PlayManager>
{
    public static Item equipItemScript;

    [SerializeField] Image image;

    [SerializeField] List<QuickSlotUi> quickSlotUis;

    public void SetQuickSlot(int code , int slotNum)
    {
        QuickSlot.slotItems[slotNum] = ItemManager.Instance.GetItemScript(code);
        quickSlotUis[slotNum].SetSlotImage(code);
    }

    public void ClearEquip()
    {
        equipItemScript = null;
        image.sprite = null;
    }

    public void TestEquip()
    {
        Debug.Log("Protect를 장착 했습니다.");

        ItemManager.Instance.SetEquip(1);

        image.sprite = ResourcesManager.Instance.Load<Sprite>(ItemManager.Instance.GetItemInfo(1).name);
    }

    public void TestHit()
    {
        OnHit();
    }

    public void OnHit()
    {
        if (equipItemScript == null)
            return;

        var function = equipItemScript as IEquipOnHit;

        if (function != null)
            function.OnHitEffect();
    }
}
