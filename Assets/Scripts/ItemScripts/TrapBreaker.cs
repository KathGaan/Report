using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBreaker : WeaponItem, IWeaponSkill
{
    public void SkillEffect()
    {
        Debug.Log("���� �������� �ı� �߽��ϴ�.");

        PlayManager.Instance.ClearEquip();
    }
}
