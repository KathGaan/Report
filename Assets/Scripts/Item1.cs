using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireBall", menuName = "ItemScrpt/FireBall", order = 0)]
public class Item1 : ItemScrpt, IUseEffect
{
    public void UseEffect()
    {
        Debug.Log("적에게 데미지를 주었다.");
    }
}
