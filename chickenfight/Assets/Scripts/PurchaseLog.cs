using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseLog : MonoBehaviour
{
    public GlobalCash GCash;
    public pickCoin piCo;
    public static double CashCount;
    public GameObject AutoMoney, AutoMoney2, AutoMoney3, AutoMoney4;
    public GameObject plusCashText, lossCashText;
    public GameObject logText;
    public GameObject pickCoinBtnAmText;

    public GameObject MPUnlockBtn1, MPUnlockBtn2, MPUnlockBtn3, MPUnlockBtn4, MPUnlockBtn5, pickCoinUpgradeBtn;
    public GameObject MPUnlockBtn1text, MPUnlockBtn2text, MPUnlockBtn3text, MPUnlockBtn4text, MPUnlockBtn5text, pickCoinUpgradeBtnText; 
    public GameObject marketUpgrade1LevelText, marketUpgrade2LevelText, marketUpgrade3LevelText;
    public GameObject upgrade10Btn, upgrade15Btn, upgrade20Btn, upgrade25Btn;

    public GameObject bribeBtn;
    public AudioSource upgradeSound;
    public static string myText;
    public static Color myColor;
    public ActionLogManager ALM;
    public proBar pBar;
    public int workWin;
    public static int betterJob = 25000;
    public static bool jobUpgrade = false;
    private static bool jobBonus;
    private static bool pickCoinUpgrade = false;
    private static int randomWorkBonus;
    private static int pickCoinUpgradePrice = 550;
    private static int randomRange;
    private int jobLevel = 0;

    public static string animText; //denne delen er for å stacke animasjonene
    public static Color animColor; // -''-
    public static Animation plusLossAnim; // -''-
    public static int fontSize;
    //public GameObject plusLossText; //dette er teksten som spiller animasjonen, objektet må ha animasjonen koblet til seg og autoplay på

    private void Update()
    {
        randomWorkBonus = Random.Range(500, 2100);
        randomRange = Random.Range(2, 4);

        if(GlobalCash.CashCount < 1000){upgrade10Btn.GetComponent<Image>().color = new Color32(176, 64, 59, 255);}
        else{upgrade10Btn.GetComponent<Image>().color = new Color32(61, 140, 62, 255);}
        if(GlobalCash.CashCount >= 5000){upgrade15Btn.GetComponent<Image>().color = new Color32(61, 140, 62, 255);}
        else{upgrade15Btn.GetComponent<Image>().color = new Color32(176, 64, 59, 255);}
        if(GlobalCash.CashCount >= 25000){upgrade20Btn.GetComponent<Image>().color = new Color32(61, 140, 62, 255);}
        else{upgrade20Btn.GetComponent<Image>().color = new Color32(176, 64, 59, 255);}
        if(GlobalCash.CashCount >= 100000){upgrade25Btn.GetComponent<Image>().color = new Color32(61, 140, 62, 255);}
        else{upgrade25Btn.GetComponent<Image>().color = new Color32(176, 64, 59, 255);}

        if (GlobalCash.CashCount >= ChickenFight.bribePrice)
        {
            bribeBtn.GetComponent<Image>().color = new Color32(59, 176, 75, 255);
        }
        else if (GlobalCash.CashCount < ChickenFight.bribePrice)
        {
            bribeBtn.GetComponent<Image>().color = new Color32(176, 64, 59, 255);
        }

        if(GlobalCash.CashCount >= pickCoinUpgradePrice)
        {
            pickCoinUpgradeBtn.GetComponent<Image>().color = new Color32(59, 176, 75, 255);
        }
        else if(GlobalCash.CashCount < pickCoinUpgradePrice)
        {
            pickCoinUpgradeBtn.GetComponent<Image>().color = new Color32(176, 64, 59, 255); 
        }

        if (GlobalCash.CashCount >= betterJob)
        {
            MPUnlockBtn1.GetComponent<Image>().color = new Color32(59, 176, 75, 255);
        }
        else if(GlobalCash.CashCount < betterJob)
        {
            MPUnlockBtn1.GetComponent<Image>().color = new Color32(176, 64, 59, 255);
        }

        if (jobBonus)
        {
            MPUnlockBtn1text.GetComponent<Text>().text = "BETTER JOB\n" + "(-" + betterJob + ")";
            jobBonus = false;
        }
        if(pickCoinUpgrade)
        {
            pickCoinUpgradeBtnText.GetComponent<Text>().text = "PICK COINS BETTER\n" + "(-" + pickCoinUpgradePrice + ")";
            pickCoinBtnAmText.GetComponent<Text>().text = "(+" + pickCoin.coinPickRate + ")";
            pickCoinUpgrade = false;

        }


    }

    public void StartAutoMoney()
    {
        if(GlobalCash.CashCount >= 1000)
        {
            GlobalCash.CashCount -= 1000;
            AutoMoney.SetActive(true);
            upgrade10Btn.SetActive(false);

            //plusCashText.GetComponent<Text>().text = "UPGRADE!";
            //plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            lossCashText.GetComponent<Text>().text = "-1000";
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");

            animText = "UPGRADE!";
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

            myColor = new Color32(59, 192, 63, 255);
            myText = ">UPGRADE! YOUR CHICKENS NOW PRODUCE 0.1 COIN EACH!";
            ALM.LogText(myText, myColor);

            upgradeSound.Play();
        }
    }

    public void Upgrade2()
    {
        if(GlobalCash.CashCount >= 5000)
        {
            GlobalCash.CashCount -= 5000;
            AutoMoney.SetActive(false);
            AutoMoney2.SetActive(true);
            upgrade15Btn.SetActive(false);

            //plusCashText.GetComponent<Text>().text = "UPGRADE!";
            //plusCashText.GetComponent<Animation>().Play("plusCashAnim");

            animText = "UPGRADE!";
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

            lossCashText.GetComponent<Text>().text = "-5000";
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");

            myColor = new Color32(59, 192, 63, 255);
            myText = ">UPGRADE! YOUR CHICKENS NOW PRODUCE 0.15 COINS EACH!";
            ALM.LogText(myText, myColor);

            upgradeSound.Play();
        }
    }

    public void Upgrade3()
    {
        if(GlobalCash.CashCount >= 25000)
        {
            GlobalCash.CashCount -= 25000;
            AutoMoney2.SetActive(false);
            AutoMoney3.SetActive(true);
            upgrade20Btn.SetActive(false);

            animText = "UPGRADE!";
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

            //plusCashText.GetComponent<Text>().text = "UPGRADE!";
            //plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            lossCashText.GetComponent<Text>().text = "-25 000";
            lossCashText.GetComponent<Animation>().Play("lossCashAnim"); 

            myColor = new Color32(59, 192, 63, 255);
            myText = ">UPGRADE! YOUR CHICKENS NOW PRODUCE 0.2 COINS EACH!";
            ALM.LogText(myText, myColor);

            upgradeSound.Play();
        }
    }

    public void Upgrade4()
    {
        if(GlobalCash.CashCount >= 100000)
        {
            GlobalCash.CashCount -= 100000;
            AutoMoney3.SetActive(false);
            AutoMoney4.SetActive(true);
            upgrade25Btn.SetActive(false);

           // plusCashText.GetComponent<Text>().text = "UPGRADE!";
           // plusCashText.GetComponent<Animation>().Play("plusCashAnim");

            animText = "UPGRADE!";
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

            lossCashText.GetComponent<Text>().text = "-100 000";
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");

            myColor = new Color32(59, 192, 63, 255);
            myText = ">UPGRADE! YOUR CHICKENS NOW PRODUCE 0.25 COINS EACH!";
            ALM.LogText(myText, myColor);

            upgradeSound.Play();
        }
    }

    public void BetterJob()
    {
        if(GlobalCash.CashCount >= betterJob)
        {
            GlobalCash.CashCount -= betterJob;
            jobUpgrade = true;
            jobBonus = true;
            pBar.workBonus += (randomWorkBonus * randomRange);
            betterJob += betterJob * 4;
            myColor = new Color32(59, 192, 63, 255);
            myText = ">PROMOTION!";
            ALM.LogText(myText, myColor);

            //plusCashText.GetComponent<Text>().text = "PROMOTION!";
            //plusCashText.GetComponent<Animation>().Play("plusCashAnim");

            animText = "PROMOTION!";
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

            lossCashText.GetComponent<Text>().text = "-" + betterJob;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");

            jobLevel++;
            marketUpgrade1LevelText.GetComponent<Text>().text = "LEVEL: " + jobLevel;
            upgradeSound.Play();
        }
    }

    public void betterPickCoin()
    {
        if(GlobalCash.CashCount >= pickCoinUpgradePrice)
        {
            GlobalCash.CashCount -= pickCoinUpgradePrice;
            pickCoinUpgrade = true;
            pickCoinUpgradePrice += Mathf.RoundToInt(pickCoinUpgradePrice * 0.5f);
            pickCoin.coinPickRate++;

            myColor = new Color32(59, 192, 63, 255);
            myText = ">UPGRADE! You now pick " + pickCoin.coinPickRate + " at a time.";
            ALM.LogText(myText, myColor);

            //plusCashText.GetComponent<Text>().text = "UPGRADE!";
            //plusCashText.GetComponent<Animation>().Play("plusCashAnim");

            animText = "UPGRADE!";
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

            lossCashText.GetComponent<Text>().text = "-" + pickCoinUpgradePrice;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");

            upgradeSound.Play();
        }           
    }
}
