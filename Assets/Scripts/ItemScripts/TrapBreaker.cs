using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBreaker : WeaponItem, IWeaponSkill
{
    public void SkillEffect()
    {
        Debug.Log("장착 아이템을 파괴 했습니다.");

        PlayManager.Instance.ClearEquip();
    }
}
