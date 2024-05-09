using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorTrap : EquipItem, IEquipOnHit, IItemTrap
{
    public void TrapEffect()
    {
        PlayManager.Instance.ClearEquip();

        Debug.Log("함정을 밟았습니다.");

        PlayManager.equipItemScript = this;
    }

    public void OnHitEffect()
    {
        Debug.Log("피해를 입고 트랩이 해제되었습니다.");

        PlayManager.Instance.ClearEquip();
    }
}
