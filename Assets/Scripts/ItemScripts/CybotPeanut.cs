using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CybotPeanut : EquipItem, IEquipOnHit
{
    protected override void SetDefault()
    {
        defense = 0;
    }

    public void OnHitEffect()
    {
        if(Random.Range(0,10) == 0)
        {
            Debug.Log("���ظ� 80% ���ҽ��ϴ�.");
        }
    }
}
