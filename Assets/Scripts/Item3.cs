using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Snow", menuName = "ItemScrpt/Snow", order = 2)]
public class Item3 : ItemScrpt, IEquipEffect
{
    public void EquipEffect()
    {
        Debug.Log("추위 증가");
    }
}
