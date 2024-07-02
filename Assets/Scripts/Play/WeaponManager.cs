using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public void ActiveAttack()
    {
        OnAttack();
    }

    public void ActiveSkill()
    {
        OnSkill();
    }

    private void OnAttack()
    {
        if (PlayManager.weaponScript == null)
            return;

        PlayManager.weaponScript.AttackEffect();
    }

    private void OnSkill()
    {
        if (PlayManager.weaponScript == null)
            return;

        var function = PlayManager.weaponScript as IWeaponReload;

        if (function != null)
            function.ReloadEffect();
    }
}
