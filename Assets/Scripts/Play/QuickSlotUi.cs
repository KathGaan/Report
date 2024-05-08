using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotUi : MonoBehaviour
{
    [SerializeField] Image image;

    [SerializeField] int slotNum;

    public void SetSlotImage(int code)
    {
        image.sprite = ResourcesManager.Instance.Load<Sprite>(ItemManager.Instance.GetItemInfo(code).name);
    }

}
