using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : ConsumeItem, IConsumeSpell
{
    public void SpellEffect()
    {
        Debug.Log("FireBall�� �߻��߽��ϴ�.");
    }
}
