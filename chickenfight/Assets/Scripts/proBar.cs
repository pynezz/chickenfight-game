using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class proBar : MonoBehaviour
{
    public GameObject logText;
    public GameObject lossCashText;
    public GameObject plusCashText;
    public ActionLogManager ALM;
    public GameController GC;
    public GlobalCash GCash;
    public AudioSource kaChing;
    public AudioSource coinStack;
    public StatusAndStats StASt;
    public PurchaseLog PuLo;
    private float LossRange;
    private int genChance;
    private int moneyCheck;
    private float moneyLoss;
    public int crimeWin, workWin, crimeWinBig, workBonus = 0, randomWorkBonus = 0;
    public Button workBtn;
    public Button crimeBtn;
    public Slider workSlider;
    public Slider crimeSlider;
    public static string myText;
    public static Color myColor;
    public static string myText1, myText2, myText3, myText4;

    public static int fontSize;
    public static string animText; //denne delen er for å stacke animasjonene
    public static Color animColor; // -''-
    public static Animation plusLossAnim; // -''-

    void Update()
    {
        if(PurchaseLog.jobUpgrade)
        {
            randomWorkBonus = Random.Range(2, 4);
        }
        moneyCheck = Random.Range(1, 13);
        // print(moneyCheck);
        LossRange = Random.Range(0.4f, 0.8f);
        crimeWin = Random.Range(1000, 10000);
        crimeWinBig = Random.Range(10000, 50000);
        workWin = (Random.Range(100, 400)) + (workBonus * randomWorkBonus);
    }
    
    public void doCrime()
    {
        if(moneyCheck == 2 || moneyCheck == 3)
        {
            GC.crime = 0;
            GlobalCash.CashCount += crimeWin;
            StatusAndStats.moneyGained += crimeWin;
            animText = "+" + crimeWin;
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

            myColor = new Color32(59, 192, 63, 255);
            myText = ">You sold a brick as an iPhone and earned " + crimeWin;
            ALM.LogText(myText, myColor);
            coinStack.Play();
        }

        else if(moneyCheck == 5)
        { 
            GC.crime = 0;
            GlobalCash.CashCount += crimeWinBig + (GlobalCash.CashCount / 2);
            StatusAndStats.moneyGained += crimeWinBig;
            animText = "+" + crimeWinBig;
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

            myText = ">WOW! You robbed a bank and got away with " + crimeWinBig + "!";
            myColor = new Color32(14, 200, 1, 255);
            ALM.LogText(myText, myColor);
            coinStack.Play();
        }
        else
        {
            GC.crime = 0;
            moneyLoss = GlobalCash.CashCount * LossRange;
            GlobalCash.CashCount -= (int)moneyLoss;
            StatusAndStats.moneyLost += (int)moneyLoss;
            lossCashText.GetComponent<Text>().text = "-" + (int)moneyLoss;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            myText = ">You got busted selling fake eggs and was fined " + (int)moneyLoss;
            myColor = new Color32(209, 112, 100, 255);
            ALM.LogText(myText, myColor);
        }
    }

    public void doWork()
    {
        GC.work = 0;
        GlobalCash.CashCount += 500000; //change for testing (workWin)
        animText = "+" + workWin;
        animColor = new Color32(59, 192, 63, 255);
        fontSize = 47;
        ALM.cashAnimation(animText, animColor, fontSize);

        myText = ">You did some honest work and earned " + workWin;
        myColor = new Color32(59, 192, 63, 255);
        ALM.LogText(myText, myColor);
        kaChing.Play();
        StatusAndStats.moneyGained += workWin;
    }
}
