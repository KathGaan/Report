using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] int code;

    private Item trapItem;

    private void Awake()
    {
        trapItem = ItemManager.Instance.GetItemScript(code);
    }

    public virtual void ActiveTrap()
    {
        var function = trapItem as IItemTrap;

        if (function != null)
            function.TrapEffect();
    }

}
