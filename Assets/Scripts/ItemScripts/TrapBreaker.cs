using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBreaker : WeaponItem, IWeaponAttack , IWeaponSkill
{

    public void AttackEffect()
    {
        Debug.Log("���� �߽��ϴ�.");
    }

    public void SkillEffect()
    {
        Debug.Log("���� �������� �ı� �߽��ϴ�.");

        PlayManager.Instance.ClearEquip();
    }
}
