using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_1 : ItemObj, IOnHit
{
    public void OnHitEffect()
    {
        Debug.Log("���ظ� ���� �ı��Ǿ����ϴ�.");

        PlayManager.Instance.ClearEquip();
    }
}
