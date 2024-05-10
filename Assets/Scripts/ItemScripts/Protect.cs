using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protect : EquipItem, IEquipOnHit
{
    protected override void SetDefault()
    {
        defense = 100;
    }

    public void OnHitEffect()
    {
        Debug.Log("���ظ� ���� �ı��Ǿ����ϴ�.");

        PlayManager.Instance.ClearEquip();
    }
}
