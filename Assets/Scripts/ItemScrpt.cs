using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScrpt : ScriptableObject
{
        
}

public interface IUseEffect
{
    public void UseEffect();
}

public interface IEquipEffect
{
    public void EquipEffect();
}