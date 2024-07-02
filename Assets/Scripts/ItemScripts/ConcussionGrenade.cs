using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcussionGrenade : StackConsumeItem
{
    public ConcussionGrenade()
    {
        maxHold = 4;
        hold = 4;
    }

    public override void UseEffect()
    {
        if (hold == 0)
            return;

        hold--;

        Debug.Log("��� ����ź�� �������ϴ�." + hold + "�� ���ҽ��ϴ�.");

        if(hold == 0)
        {
            base.UseEffect();
        }
    }
}
