using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_1 : ItemObj, IOnHit
{
    public void OnHitEffect()
    {
        Debug.Log("피해를 막고 파괴되었습니다.");

        PlayManager.Instance.ClearEquip();
    }
}
