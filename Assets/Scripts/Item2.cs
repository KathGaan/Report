using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Protect", menuName = "ItemScrpt/Protect", order = 1)]
public class Item2 : ItemScrpt, IEquipEffect, IUseEffect
{
    public void EquipEffect()
    {
        Debug.Log("��ȣ�� ����");
    }

    public void UseEffect()
    {
        Debug.Log("��ȣ�� ����");
    }
}
