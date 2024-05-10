using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int code;

    public string name;

    public string type;
    public string description;
}

public class ConsumeItem : Item
{
    public int count;
}

public class EquipItem : Item
{
    public float defense;
    
    protected EquipItem()
    {
        SetDefault();
    }

    protected virtual void SetDefault()
    {
        defense = 0;
    }
}

public class WeaponItem : Item
{
    public virtual void AttackEffect()
    {
        Debug.Log("기본 공격을 했습니다.");
    }
}

public interface IConsumeSpell
{
    public void SpellEffect();
}

public interface IEquipOnHit
{
    public void OnHitEffect();
}

public interface IItemTrap
{
    public void TrapEffect();
}

public interface IWeaponSkill
{
    public void SkillEffect();
}