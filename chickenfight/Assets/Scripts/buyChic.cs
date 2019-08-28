using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class buyChic : MonoBehaviour
{
    public GlobalCash GCash;
    public GameObject plusCashText;
    public GameObject lossCashText;
    public AudioSource chicBak;
    //public GameObject logText;
    //public GameObject logPanel;
    public GameObject buyChickenBtn;
    public StatusAndStats StASt;
    public GameObject ArmChickBtn, ArmChicBtnText;
    public GameObject changeBuyAmntBtn, changeBuyAmntText;

    public ActionLogManager ALM; //denne styrer animasjoner og stacking av objekter
    public static string myText;
    public static Color myColor;

    private bool AChickenPriceIncrease;
    private static int ArmChicPrice = 5000;

    public static string animText; //denne delen er for å stacke animasjonene
    public static Color animColor; // -''-
    public static Animation plusLossAnim; // -''-
    public static int fontSize;

    public static int buyChicAmount = 1, buyChicAmountUpdate, buyChicMathConversion;

    public static int chickenAmountToBuy;

    public int cashRemainder, chickensToAfford;

    public static int ChickenPrice;

    public bool chickenUpdate = false;


    // Update is called once per frame
    void Update()
    {
        ChickenPrice = chickenAmountToBuy * 50;

        if(chickenUpdate == false)
        {
            chickenUpdate = true;
            StartCoroutine(ChickenPriceUpdater());
        }

        if(buyChicAmount == 1)
        {
            changeBuyAmntText.GetComponent<Text>().text = "BUY #1";
            chickenAmountToBuy = 1;
        }

        if (GlobalCash.CashCount < 50)
        {
            buyChickenBtn.GetComponent<Image>().color = new Color32(176, 64, 59, 255);
        }

        else if(GlobalCash.CashCount > 50)
        {
            buyChickenBtn.GetComponent<Image>().color = new Color32(61, 140, 62, 255);
        }

        if (GlobalCash.CashCount >= ArmChicPrice)
        {
            ArmChickBtn.GetComponent<Image>().color = new Color32(59, 176, 75, 255);
        }
        else
        {
            ArmChickBtn.GetComponent<Image>().color = new Color32(176, 64, 59, 255);
        }

        if(AChickenPriceIncrease)
        {
            ArmChicBtnText.GetComponent<Text>().text = "ARMORED CHICKEN\n" + "(-" + ArmChicPrice + ")";
            AChickenPriceIncrease = false;
        }
    }

    public void buyChick()
    {
        if(GlobalCash.CashCount >= ChickenPrice)
        {
            chicBak.Play();
            GlobalChickens.ChickenCount += chickenAmountToBuy;
            StatusAndStats.chickensBought += chickenAmountToBuy;
            GlobalCash.CashCount -= ChickenPrice;
            //plusCashText.GetComponent<Text>().text = "+ 1 Chicken";
            //plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            animText = "+" + chickenAmountToBuy + " Chicken(s)";
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 32;
            ALM.cashAnimation(animText, animColor, fontSize);

            myText = ">You bought " + chickenAmountToBuy + " chicken(s)";
            myColor = new Color32(233, 233, 233, 255);
            ALM.LogText(myText, myColor);
        }

        else if((GlobalCash.CashCount < ChickenPrice) && (GlobalCash.CashCount >= 50))
        {
            cashRemainder = (Convert.ToInt32(Mathf.Floor(GlobalCash.CashCount)) % 50);
            chickensToAfford = ((int)GlobalCash.CashCount - cashRemainder) / 50;
            GlobalCash.CashCount -= chickensToAfford * 50;
            GlobalChickens.ChickenCount += chickensToAfford;

            animText = "+" + chickensToAfford + " Chickens(s)";
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 32;
            ALM.cashAnimation(animText, animColor, fontSize);

            myText = ">You bought " + chickensToAfford + " chicken(s)";
            myColor = new Color32(233, 233, 233, 255);
            ALM.LogText(myText, myColor);
        }

        else
        {

        }
    }

    public void buyArmChick()
    {
        if(GlobalCash.CashCount >= ArmChicPrice)
        {
            GlobalChickens.AChickenCount += 1;
            StatusAndStats.chickensBought += 1;
            GlobalCash.CashCount -= ArmChicPrice;

           // plusCashText.GetComponent<Text>().text = "+ 1 Armored Chicken";
           // plusCashText.GetComponent<Animation>().Play("plusCashAnim");

            animText = "+1 Armored Chicken!";
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 32;
            ALM.cashAnimation(animText, animColor, fontSize);

            myText = ">You bought an Armored Chicken";
            myColor = new Color32(233, 233, 233, 255);
            ALM.LogText(myText, myColor);

            AChickenPriceIncrease = true;
            ArmChicPrice += 100;
        }

        else if(GlobalCash.CashCount < 5000)
        {

        }
    }

    public void changeBuyAmountBtnClick()
    {
        buyChicAmount++;
    }

    public void changeBuyAmount()
    {
        buyChicAmount++;
        chickenUpdate = true;
        switch (buyChicAmount)
        {
            case 1:
                changeBuyAmntText.GetComponent<Text>().text = "BUY #1";
                break;
            case 2:
                changeBuyAmntText.GetComponent<Text>().text = "BUY #5";
                chickenAmountToBuy = 5;
                break;
            case 3:
                changeBuyAmntText.GetComponent<Text>().text = "BUY #10";
                chickenAmountToBuy = 10;
                break;
            case 4:
                changeBuyAmntText.GetComponent<Text>().text = "BUY #50";
                chickenAmountToBuy = 50;
                break;
            case 5:
                changeBuyAmntText.GetComponent<Text>().text = "BUY #100";
                chickenAmountToBuy = 100;
                break;
            case 6:
                changeBuyAmntText.GetComponent<Text>().text = "BUY #1000";
                chickenAmountToBuy = 1000;
                break;
            case 7:
                buyChicAmount = 1; 
                break;
            default:
                break;
        }


    }

    IEnumerator ChickenPriceUpdater()
    {
        
        yield return new WaitForEndOfFrame();
        chickenUpdate = false;
    }
}
