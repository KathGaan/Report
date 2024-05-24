using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : ConsumeItem
{
    public override void UseEffect()
    {
        Debug.Log("FireBall을 발사했습니다.");

        base.UseEffect();
    }
}
