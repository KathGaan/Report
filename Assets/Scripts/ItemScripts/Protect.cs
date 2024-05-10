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
        Debug.Log("피해를 막고 파괴되었습니다.");

        PlayManager.Instance.ClearEquip();
    }
}
