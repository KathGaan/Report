using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem
{
    public static ItemObj equipItemScript;

    public void OnHit()
    {
        if (equipItemScript == null)
            return;

        var function = equipItemScript as IOnHit;

        if (function != null)
            function.OnHitEffect();
    }

    //...
}
