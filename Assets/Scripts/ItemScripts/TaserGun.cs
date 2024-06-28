using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserGun : WeaponItem, IWeaponSkill
{
    private const int maxAmmo = 4;

    private int currentAmmo;

    public TaserGun()
    {
        currentAmmo = maxAmmo;
    }

    public override void AttackEffect()
    {
        if(currentAmmo <= 0)
        {
            Debug.Log("������ ���� �߻��Ϸ� ������, �����Ǿ� �ִ� ź���� �����ϴ�.");
            SkillEffect();
            return;
        }

        currentAmmo--;

        Debug.Log("������ ���� �߻� �߽��ϴ�." + currentAmmo + "�� ���ҽ��ϴ�.");
    }

    public void SkillEffect()
    {
        Debug.Log("������ �մϴ�.");

        currentAmmo = maxAmmo;
    }
}
