using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : CoolDownItem
{
    protected override void SetDefault()
    {
        coolDown = 5f;
        canUse = true;
    }

    public override void UseEffect()
    {
        if (!canUse)
            return;

        Debug.Log("�κ��� ���� �߽��ϴ�.");
    }
}
