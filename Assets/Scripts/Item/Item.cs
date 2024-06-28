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
    public bool usedSuccess;

    public virtual void UseEffect()
    {
        usedSuccess = true;
    }

    public void UsedSuccess(QuickSlotUi obj)
    {
        obj.ClearSlot();
        usedSuccess = false;
    }
}

public class CoolDownItem : Item
{   
    public float coolDown;

    public bool canUse;

    protected CoolDownItem()
    {
        SetDefault();
    }

    public virtual void UseEffect()
    {
        if (!canUse)
            return;
    }

    protected virtual void SetDefault()
    {
        coolDown = 0;
        canUse = true;
    }

    public void UsedSuccess(QuickSlotUi obj)
    {
        canUse = false;
        obj.CoolDownStart(this);
    }
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
        Debug.Log("�⺻ ������ �߽��ϴ�.");
    }
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

public class StackConsumeItem : ConsumeItem
{
    protected int maxHold;

    protected int hold = 0;

    public StackConsumeItem()
    {
        maxHold = 2;
    }

    public bool MaxCheck()
    {
        if (hold >= maxHold)
            return true;

        return false;
    }

    public bool HoldCheck()
    {
        if (hold == 0)
            return false;

        return true;
    }

    public void AddHold(int value = 1)
    {
        hold += value;

        if(hold > maxHold)
        {
            hold = maxHold;
        }
    }
}


public enum ItemType
{
    Consume,
    CoolDown,
    Equip,
    Weapon,


    Count
}