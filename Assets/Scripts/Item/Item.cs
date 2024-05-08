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

public interface IConsumeSpell
{
    public void SpellEffect();
}

public interface IEquipOnHit
{
    public void OnHitEffect();
}
