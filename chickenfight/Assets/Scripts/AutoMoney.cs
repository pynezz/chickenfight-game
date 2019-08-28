using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoney : MonoBehaviour
{
    public bool genMoney = false;
    public static int moneyIncrease;
    public static int internalIncrease;
    public GlobalCash GCash;
    public float CashCount;
    public GlobalChickens GChick;
    public StatusAndStats StASt;

    private float time = 10f;

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
            StartCoroutine(generateMoneyFromChickens());
            internalIncrease = moneyIncrease;
            moneyIncrease = Mathf.RoundToInt(GlobalChickens.ChickenCount * 0.1f); //SJEKKE HER, 
            StatusAndStats.moneyGained += internalIncrease;
             // flytte denne til coroutine, sjekk automoney2
        }
    }

    IEnumerator generateMoneyFromChickens()
    {
        // flytte denne til update
        GlobalCash.CashCount += internalIncrease;
        yield return new WaitForSeconds(1); // endre til 1
        genMoney = false;

    }
}