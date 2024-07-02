using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : HealthBar
{
    [SerializeField] Image damagedGuage;

    private bool chainStart;

    private float chainTimer = 0f;

    private float chainTime = 1.25f;

    protected override void Start()
    {
        base.Start();

        damagedGuage.fillAmount = Health;
    }

    public override IEnumerator ChangeHealthGuage(float damage)
    {
        StartCoroutine(base.ChangeHealthGuage(damage));

        if(!chainStart)
        {
            StartCoroutine(ChangeDamagedGuage());
            chainStart = true;
            yield break;
        }
        else
        {
            chainTimer = chainTime;
        }
    }

    private IEnumerator ChangeDamagedGuage()
    {
        chainTimer = chainTime;

        while (true)
        {
            chainTimer -= Time.deltaTime;

            if (chainTimer <= 0f)
            {
                damagedGuage.fillAmount = healthGuage.fillAmount;
                chainStart = false;
                break;
            }

            yield return null;
        }
    }
}
