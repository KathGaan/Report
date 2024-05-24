using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : ConsumeItem
{
    public override void UseEffect()
    {
        if (PlayManager.playerLocate == Locate.Outside)
        {
            Debug.Log("수류탄을 던졌습니다.");

            base.UseEffect();
        }
        else
        {
            Debug.Log("실외에서만 사용할 수 있습니다.");
        }
    }
}
