using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Locate
{
    Inside,
    Outside,
    Rooftop
}

public class PlayManager : MonoSingletonManager<PlayManager>
{
    public static EquipItem equipItemScript;

    public static WeaponItem weaponScript;

    public static Locate playerLocate;

    [SerializeField] TextMeshProUGUI Info;


    public void ClearEquip()
    {
        equipItemScript = null;
    }

    public void ClearWeapon()
    {
        weaponScript = null;
    }

    public void TestWeapon()
    {
        Debug.Log("TrapBreaker를 장착 했습니다.");

        weaponScript = ItemManager.Instance.SetWeapon(3);
    }

    public void TestEquip()
    {
        Debug.Log("Protect를 장착 했습니다.");

        equipItemScript = ItemManager.Instance.SetEquip(1);
    }

    public void TestHit()
    {
        OnHit();
    }

    public void OnHit()
    {
        if (equipItemScript == null)
            return;

        var function = equipItemScript as IEquipOnHit;

        if (function != null)
            function.OnHitEffect();
    }

    public void MoveInside()
    {
        playerLocate = Locate.Inside;

        Debug.Log("실내로 이동했습니다.");
    }

    public void MoveOutside()
    {
        playerLocate = Locate.Outside;

        Debug.Log("실외로 이동했습니다.");
    }

    public void MoveRooftop()
    {
        playerLocate = Locate.Rooftop;

        Debug.Log("옥상으로 이동했습니다.");
    }


    public void ItemInfo()
    {
        Info.text = null;

        Item item = null;

        if (equipItemScript != null)
        {
            item = ItemManager.Instance.GetItemInfo(equipItemScript.code);

            Info.text = item.name + "\n" + item.type + "\n방어도 : " + equipItemScript.defense + "\n" + item.description + "\n\n";
        }

        if (weaponScript != null)
        {
            item = ItemManager.Instance.GetItemInfo(weaponScript.code);

            Info.text += item.name + "\n" + item.type + "\n" + item.description;
        }
    }
}
