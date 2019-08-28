using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoney3 : MonoBehaviour
{
    public bool genMoney = false;
    public static int moneyIncrease;
    public static int internalIncrease;
    public GlobalCash GCash;
    public float CashCount;
    public GlobalChickens GChick;
    public StatusAndStats StASt;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (genMoney == false)
        {
            genMoney = true;
            internalIncrease = moneyIncrease;
            moneyIncrease = Mathf.RoundToInt(GlobalChickens.ChickenCount * 0.2f);
            StartCoroutine(generateMoneyFromChickens());
            StatusAndStats.moneyGained += (int)internalIncrease;
        }
    }

    IEnumerator generateMoneyFromChickens()
    {
        GlobalCash.CashCount += internalIncrease;
        yield return new WaitForSeconds(1);
        genMoney = false;

    }
}
