using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : ConsumeItem
{
    public override void UseEffect()
    {
        if (PlayManager.playerLocate == Locate.Outside)
        {
            Debug.Log("����ź�� �������ϴ�.");

            base.UseEffect();
        }
        else
        {
            Debug.Log("�ǿܿ����� ����� �� �ֽ��ϴ�.");
        }
    }
}
