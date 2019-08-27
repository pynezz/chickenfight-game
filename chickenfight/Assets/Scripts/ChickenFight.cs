using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenFight : MonoBehaviour
{
    public InputField betField;
    public GlobalCash GCash;
    public StatusAndStats StASt;
    public ActionLogManager ALM;
    public GameController GC;
    public GlobalChickens GChick;
    public GameObject betText;
    public GameObject plusCashText, lossCashText, buttonBribePriceText;
    public GameObject logText;
    public GameObject fightChickenBtn, bribeBtn, bribeBtnDisabled, chooseAnAmountBtn;
    public AudioSource winSound, loseSound;
    public Slider betSlider;
    private float betCheck;
    public float betAmount = 0;
    public Toggle ToggleArmChicken;
    public static string myText;
    public static Color myColor;
    public static bool bribe = false;
    public static int bribePrice = 50000;

    public void Update()
    {
        betSlider.maxValue = GlobalCash.CashCount;
        betCheck = Random.Range(1, 1001);
        //print(betCheck);
        if(betAmount > 50)
        {
            chooseAnAmountBtn.SetActive(false);
        }

        else if (betAmount <= 50)
        {
            chooseAnAmountBtn.SetActive(true);
        }

        if (GlobalChickens.AChickenCount >= 1)
        {
            ToggleArmChicken.interactable = true;
        }

        else if (GlobalChickens.AChickenCount <= 0)
        {
            ToggleArmChicken.interactable = false;
        }
    }

    public void AdjustBet (float newBet)
    {
        betAmount = newBet;
        betText.GetComponent<Text>().text = "" + betAmount;
    }

    public void Bribe()
    {
        if(GlobalCash.CashCount >= bribePrice)
        {
            bribe = true;
            GlobalCash.CashCount -= bribePrice;
            lossCashText.GetComponent<Text>().text = "" + bribePrice;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            myText = ">You bribed the judge for " + bribePrice;
            myColor = new Color32(233, 233, 233, 255);
            ALM.LogText(myText, myColor);
            bribeBtn.SetActive(false);
        }
    }


    public void PlaceBet()
    {

        if (bribe && betCheck <= 990)
        {
            GlobalCash.CashCount += betAmount;
            StatusAndStats.moneyGained += (int)betAmount;
            betText.GetComponent<Text>().text = "WIN!";
            plusCashText.GetComponent<Text>().text = "+ " + betAmount;
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            myText = ">You won a chickenfight and won " + betAmount;
            myColor = new Color32(59, 192, 63, 255);
            ALM.LogText(myText, myColor);
            winSound.Play();
            bribePrice = bribePrice * 4;
            bribe = false;
            buttonBribePriceText.GetComponent<Text>().text = "BRIBE THE JUDGE \n(-" + bribePrice + ")";
            bribeBtn.SetActive(true);
            betSlider.value = 0.1f;

        }

        else if (betCheck % 2 == 0)
        {
            GlobalCash.CashCount += betAmount;
            StatusAndStats.moneyGained += (int)betAmount;
            StatusAndStats.fightsWon += 1;
            betText.GetComponent<Text>().text = "WIN!";
            plusCashText.GetComponent<Text>().text = "+ " + betAmount;
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            myText = ">You won a chickenfight and won " + betAmount;
            myColor = new Color32(59, 192, 63, 255);
            ALM.LogText(myText, myColor);
            winSound.Play();
            betSlider.value = 0.1f;

        }

        else
        {
            GlobalCash.CashCount -= betAmount;
            GlobalChickens.ChickenCount -= 1;
            StatusAndStats.chickensLost += 1;
            StatusAndStats.moneyLost += (int)betAmount;
            betText.GetComponent<Text>().text = "Your chicken died.";
            lossCashText.GetComponent<Text>().text = "" + betAmount;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            myText = ">Your chicken died! You lost " + betAmount;
            myColor = new Color32(209, 112, 100, 255);
            ALM.LogText(myText, myColor);
            //loseSound.Play();
            betSlider.value = 0.1f;

        }
    } 

    public void placeArmoredBet()
    {
        if (bribe && betCheck <= 990)
        {
            GlobalCash.CashCount += betAmount;
            StatusAndStats.moneyGained += (int)betAmount;
            betText.GetComponent<Text>().text = "WIN!";
            plusCashText.GetComponent<Text>().text = "+ " + betAmount;
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            myText = ">You won a chickenfight and won " + betAmount;
            myColor = new Color32(59, 192, 63, 255);
            ALM.LogText(myText, myColor);
            winSound.Play();
            bribePrice = bribePrice * 4;
            bribe = false;
            buttonBribePriceText.GetComponent<Text>().text = "BRIBE THE JUDGE \n(-" + bribePrice + ")";
            bribeBtn.SetActive(true);
            betSlider.value = 0.1f;

        }

        else if (betCheck <= 50 || betCheck >= 460)
        {
            GlobalCash.CashCount += betAmount;
            StatusAndStats.moneyGained += (int)betAmount;
            StatusAndStats.fightsWon += 1;
            betText.GetComponent<Text>().text = "WIN!";
            plusCashText.GetComponent<Text>().text = "+ " + betAmount;
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            myText = ">Your chicken won! You gained " + betAmount;
            myColor = new Color32(59, 192, 63, 255);
            ALM.LogText(myText, myColor);
            winSound.Play();
            betSlider.value = 0.1f;

        }

        else
        {
            GlobalCash.CashCount -= betAmount;
            GlobalChickens.AChickenCount -= 1;
            StatusAndStats.moneyLost += (int)betAmount;
            StatusAndStats.chickensLost += 1; 
            betText.GetComponent<Text>().text = "Your armored chicken died.";
            lossCashText.GetComponent<Text>().text = "" + betAmount;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            myText = ">Your armored chicken died! You lost " + betAmount;
            myColor = new Color32(209, 112, 100, 255);
            ALM.LogText(myText, myColor);
            loseSound.Play();
            betSlider.value = 0.1f;

        }
    }

  /**  public void armoredChickenBet()
    {
        if(ToggleArmChicken == true)
        {
            fightChickenBtn.SetActive(false);
            armChickenToggleScript.SetActive(true);
        }
    }
    */

    /**    public void AllIn(string allIn)
        {
            
        }

        public void halfIn(string halfIn)
        {

        }

        public void fightChicken(string FightChicken)
        {
            FightChicken = GetComponent<InputField>().text + betAmount;
            betAmount = double.Parse(FightChicken);

            if (betAmount >= GlobalCash.CashCount)
            {
                betAmount -= GlobalCash.CashCount;
            }
            
        }*/




}
