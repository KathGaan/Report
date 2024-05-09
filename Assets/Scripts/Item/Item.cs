using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public int code;

    public string name;

    public string type;
    public string description;
}

public abstract class ConsumeItem : Item
{

}

public abstract class EquipItem : Item
{

}

public abstract class WeaponItem : Item
{

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

public interface IWeaponAttack
{
    public void AttackEffect();
}

public interface IWeaponSkill
{
    public void SkillEffect();
}