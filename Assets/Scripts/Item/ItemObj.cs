using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObj
{

}

[Serializable]
public class Item
{
    public int code;

    public string name;
    public string type;
    public string description;
}

public interface IUse
{
    public void UseEffect();
}

public interface IOnHit
{
    public void OnHitEffect();
}
