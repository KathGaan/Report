using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_0 : ItemObj, IUse
{
    public void UseEffect()
    {
        Debug.Log("FireBall을 발사했습니다.");
    }
}
