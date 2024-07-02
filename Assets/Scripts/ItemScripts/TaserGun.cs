using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserGun : WeaponItem, IWeaponReload
{
    public TaserGun()
    {
        currentAmmo = maxAmmo;
    }

    public override void AttackEffect()
    {
        if(currentAmmo <= 0)
        {
            Debug.Log("������ ���� �߻��Ϸ� ������, �����Ǿ� �ִ� ź���� �����ϴ�.");
            ReloadEffect();
            return;
        }

        currentAmmo--;

        Debug.Log("������ ���� �߻� �߽��ϴ�." + currentAmmo + "�� ���ҽ��ϴ�.");
    }

    public void ReloadEffect()
    {
        Debug.Log("������ �մϴ�.");

        currentAmmo = maxAmmo;
    }
}
