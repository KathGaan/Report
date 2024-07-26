using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrenade : StackConsumeItem
{
    public FireGrenade()
    {
        maxHold = 3;
    }

    public override void UseEffect()
    {
        if (hold == 0)
            return;

        hold--;

        Debug.Log("ȭ�� ����ź�� �������ϴ�." + hold + "�� ���ҽ��ϴ�.");

        if (hold == 0)
        {
            base.UseEffect();
        }
    }
}
