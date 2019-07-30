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


    public float LossRange;
    public int genChance;
    public int moneyCheck;
    public float moneyLoss;
    public int workMaxVal = 50;
    public int crimeMaxVal = 30;
    private int crimeWin;
    private int workWin;


    // public int pickMaxVal = 1;

    public Button workBtn;
    public Button crimeBtn;


    public Slider workSlider;
    public Slider crimeSlider;
    // public Slider pickCoinSlider;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        moneyCheck = Random.Range(1, 4);
        // print(moneyCheck);
        LossRange = Random.Range(0.1f, 1.3f);

        crimeWin = Random.Range(1000, 10000);
        workWin = Random.Range(100, 400);
    }
    

    public void doCrime()
    {
        if(moneyCheck == 2)
        {
            GC.crime = 0;
            GlobalCash.CashCount += crimeWin;
            plusCashText.GetComponent<Text>().text = "+ " + crimeWin;
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            logText.GetComponent<Text>().text += ">You sold a brick as an iPhone on Craigslist and earned " + crimeWin + "\n";
        }
        else if(moneyCheck != 2)
        {
            GC.crime = 0;
            moneyLoss = GlobalCash.CashCount * LossRange;
            GlobalCash.CashCount -= moneyLoss;
            lossCashText.GetComponent<Text>().text = "-" + moneyLoss;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            logText.GetComponent<Text>().text += ">You got busted stealing ladders and was fined " + moneyLoss + " \n";

        }

    }


    public void doWork()
    {
        GC.work = 0;
        GlobalCash.CashCount += workWin;
        plusCashText.GetComponent<Text>().text = "+ " + workWin;
        plusCashText.GetComponent<Animation>().Play("plusCashAnim");
        logText.GetComponent<Text>().text += ">You did some honest work and earned " + workWin + " \n";


    }

    /**public void pickCoin()
    {
        GC.coin = 0;
        GlobalCash.CashCount += 1;
    }*/

}
