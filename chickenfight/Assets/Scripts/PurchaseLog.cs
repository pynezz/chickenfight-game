using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseLog : MonoBehaviour
{
    public GameObject AutoMoney;
    public GameObject AutoMoney2;
    public GlobalCash GCash;
    public static double CashCount;
    public GameObject plusCashText;
    public GameObject lossCashText;
    public GameObject logText;
    public GameObject upgrade10Btn;
    public GameObject upgrade15Btn; 
    public AudioSource upgradeSound;


    public void StartAutoMoney()
    {
        if(GlobalCash.CashCount >= 1000)
        {
            AutoMoney.SetActive(true);
            logText.GetComponent<Text>().text += "UPGRADE! YOUR CHICKENS NOW PRODUCE 0.1 COIN EACH! \n";
            plusCashText.GetComponent<Text>().text = "UPGRADE!";
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            upgrade10Btn.SetActive(false);
            GlobalCash.CashCount -= 1000;
            lossCashText.GetComponent<Text>().text = "-1000";
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            upgradeSound.Play();
        }
    }


    public void Upgrade2()
    {
        if(GlobalCash.CashCount >= 5000)
        {
            AutoMoney.SetActive(false);
            AutoMoney2.SetActive(true);
            logText.GetComponent<Text>().text += "UPGRADE! YOUR CHICKENS NOW PRODUCE 0.15 COINS EACH! \n";
            plusCashText.GetComponent<Text>().text = "UPGRADE!";
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            upgrade15Btn.SetActive(false);
            GlobalCash.CashCount -= 5000;
            lossCashText.GetComponent<Text>().text = "-5000";
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            upgradeSound.Play();
        }
    }
}
