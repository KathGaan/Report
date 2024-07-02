using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    private WeaponItem weapon;

    [SerializeField] List<Transform> bullts;

    [SerializeField] TextMeshProUGUI bulletLimit;

    private void Start()
    {
        weapon = QuickSlot.slotItems[QuickSlot.slotItems.Count - 1] as WeaponItem;
        if(weapon == null)
        {
            Destroy(gameObject);
        }

        SetBulletInfo();

        InputManager.Instance.keyDownAction += InputKey;
    }

    private void OnDisable()
    {

        InputManager.Instance.keyDownAction -= InputKey;
    }

    public void Shot()
    {
        weapon.AttackEffect();

        if (weapon.currentAmmo >= weapon.maxAmmo)
        {
            SetBulletInfo();
            return;
        }


        bullts[weapon.currentAmmo].GetChild(0).gameObject.SetActive(false);
        

        bulletLimit.text = weapon.currentAmmo.ToString();
    }

    public void Reload()
    {
        var Reload = weapon as IWeaponReload;
        if(Reload == null)
            return;

        Reload.ReloadEffect();

        SetBulletInfo();
    }

    private void SetBulletInfo()
    {
        bulletLimit.text = weapon.currentAmmo.ToString();

        for (int i = 0; i < weapon.currentAmmo; i++)
        {
            bullts[i].GetChild(0).gameObject.SetActive(true);
        }
    }

    public void InputKey()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
}
