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
            Debug.Log("테이저 건을 발사하려 했으나, 장전되어 있는 탄약이 없습니다.");
            SkillEffect();
            return;
        }

        currentAmmo--;

        Debug.Log("테이저 건을 발사 했습니다." + currentAmmo + "발 남았습니다.");
    }

    public void SkillEffect()
    {
        Debug.Log("재장전 합니다.");

        currentAmmo = maxAmmo;
    }
}
