using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protect : EquipItem, IEquipOnHit
{
    public void OnHitEffect()
    {
        Debug.Log("���ظ� ���� �ı��Ǿ����ϴ�.");

        PlayManager.Instance.ClearEquip();
    }
}
