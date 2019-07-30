using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoney : MonoBehaviour
{
    public bool genMoney = false;
    public static float moneyIncrease;
    public static float internalIncrease;
    public GlobalCash GCash;
    public float CashCount;
    public GlobalChickens GChick;


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
            moneyIncrease = GlobalChickens.ChickenCount * 0.1f;
            StartCoroutine(generateMoneyFromChickens());
        }
    }

    IEnumerator generateMoneyFromChickens()
    {
        GlobalCash.CashCount += internalIncrease;
        yield return new WaitForSeconds(1);
        genMoney = false;
        
    }
}
