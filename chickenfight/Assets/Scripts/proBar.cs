using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class proBar : MonoBehaviour
{
    public GameObject logText;
    public GameObject lossCashText;
    public GameObject plusCashText;
    public GameController GC;
    public GlobalCash GCash;
    public AudioSource kaChing;
    public AudioSource coinStack;

    private float LossRange;
    private int genChance;
    private int moneyCheck;
    private float moneyLoss;
    private int workMaxVal = 50;
    private int crimeMaxVal = 30;
    private int crimeWin;
    private int workWin;
    private int crimeWinBig;
    public Button workBtn;
    public Button crimeBtn;
    public Slider workSlider;
    public Slider crimeSlider;

    void Update()
    {

        moneyCheck = Random.Range(1, 13);
        // print(moneyCheck);
        LossRange = Random.Range(0.4f, 0.8f);
        crimeWin = Random.Range(1000, 10000);
        crimeWinBig = Random.Range(10000, 50000);
        workWin = Random.Range(100, 400);
    }
    
    public void doCrime()
    {
        if(moneyCheck == 2 || moneyCheck == 3)
        {
            GC.crime = 0;
            GlobalCash.CashCount += crimeWin ;
            plusCashText.GetComponent<Text>().text = "+ " + crimeWin;
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            logText.GetComponent<Text>().text += ">You sold a brick as an iPhone on Craigslist and earned " + crimeWin + "\n";
            coinStack.Play();
        }
        else if(moneyCheck == 5)
        { 
            GC.crime = 0;
            GlobalCash.CashCount += crimeWinBig + (GlobalCash.CashCount / 2);
            plusCashText.GetComponent<Text>().text = "+ " + crimeWinBig;
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            logText.GetComponent<Text>().text += ">WOW! You robbed a bank and got away with " + crimeWinBig + "!\n";
            coinStack.Play();
        }
        else
        {
            GC.crime = 0;
            moneyLoss = GlobalCash.CashCount * LossRange;
            GlobalCash.CashCount -= (int)moneyLoss;
            lossCashText.GetComponent<Text>().text = "-" + (int)moneyLoss;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            logText.GetComponent<Text>().text += ">You got busted stealing ladders and was fined " + (int)moneyLoss + " \n";
        }
    }

    public void doWork()
    {
        GC.work = 0;
        GlobalCash.CashCount += workWin; //change for testing
        plusCashText.GetComponent<Text>().text = "+ " + workWin;
        plusCashText.GetComponent<Animation>().Play("plusCashAnim");
        logText.GetComponent<Text>().text += ">You did some honest work and earned " + workWin + " \n";
        kaChing.Play();

    }
}
