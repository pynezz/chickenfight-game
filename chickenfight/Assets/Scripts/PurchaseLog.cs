using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseLog : MonoBehaviour
{
    public GameObject AutoMoney;
    public GlobalCash GCash;
    public static double CashCount;
    public GameObject plusCashText;
    public GameObject lossCashText;
    public GameObject logText;
    public GameObject upgrade10Btn;
    public AudioSource upgradeSound;


    public void StartAutoMoney()
    {
        if(GlobalCash.CashCount >= 1000)
        {
            AutoMoney.SetActive(true);
            logText.GetComponent<Text>().text += "UPGRADE! YOUR CHICKENS NOW PRODUCE 0.1 COIN EACH!";
            plusCashText.GetComponent<Text>().text = "UPGRADE!";
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            upgrade10Btn.SetActive(false);
            GlobalCash.CashCount -= 1000;
            lossCashText.GetComponent<Text>().text += "-1000";
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            upgradeSound.Play();
        }
    }
}
