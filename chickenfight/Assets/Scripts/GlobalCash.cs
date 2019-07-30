using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCash : MonoBehaviour
{

    public static float CashCount;
    public GameObject totalCash;
    private float InternalCash;

    // Update is called once per frame
    void Update()
    {
        InternalCash = CashCount;
        totalCash.GetComponent<Text>().text = "AMOUNT OF CASH: " + (int)InternalCash;
    }


}
