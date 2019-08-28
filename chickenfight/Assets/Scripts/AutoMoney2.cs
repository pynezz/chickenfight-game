using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoney2 : MonoBehaviour
{
    public bool genMoney = false;
    public static int moneyIncrease;
    public static int internalIncrease;
    public GlobalCash GCash;
    public float CashCount;
    public GlobalChickens GChick;
    public StatusAndStats StASt;

    void Update()
    {
        if (genMoney == false)
        {
            genMoney = true;
            internalIncrease = moneyIncrease;
            moneyIncrease = Mathf.RoundToInt(GlobalChickens.ChickenCount * 0.15f);
            StartCoroutine(generateMoneyFromChickens());
            StatusAndStats.moneyGained += internalIncrease;
        }
    }
    IEnumerator generateMoneyFromChickens()
    {
        GlobalCash.CashCount += internalIncrease;
        yield return new WaitForSeconds(1);
        genMoney = false;
    }
}