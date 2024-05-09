using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorTrap : EquipItem, IEquipOnHit, IItemTrap
{
    public void TrapEffect()
    {
        PlayManager.Instance.ClearEquip();

        Debug.Log("������ ��ҽ��ϴ�.");

        PlayManager.equipItemScript = this;
    }

    public void OnHitEffect()
    {
        Debug.Log("���ظ� �԰� Ʈ���� �����Ǿ����ϴ�.");

        PlayManager.Instance.ClearEquip();
    }
}
