using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenFight : MonoBehaviour
{
    public InputField betField;
    public GlobalCash GCash;
    public GameController GC;
    public GlobalChickens GChick;
    public float betAmount = 0;
    public GameObject betText;
    public GameObject plusCashText;
    public GameObject lossCashText;
    public GameObject logText;
    public GameObject fightChickenBtn;
    public GameObject chooseAnAmountBtn;
    public AudioSource winSound;
    public AudioSource loseSound;
    public Slider betSlider;
    private float betCheck;
    public Toggle ToggleArmChicken;

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


    public void PlaceBet()
    {
        if(betCheck % 2 == 0)
        {
            GlobalCash.CashCount += betAmount;
            betText.GetComponent<Text>().text = "WIN!";
            plusCashText.GetComponent<Text>().text = "+ " + betAmount;
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            logText.GetComponent<Text>().text += ">You won a chickenfight and won " + betAmount + "\n";
            winSound.Play();
        }

        else
        {
            GlobalCash.CashCount -= betAmount;
            betText.GetComponent<Text>().text = "Your chicken died.";
            GlobalChickens.ChickenCount -= 1;
            lossCashText.GetComponent<Text>().text = "" + betAmount;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            logText.GetComponent<Text>().text += ">Your chicken died! You lost " + betAmount + "\n";
            loseSound.Play();
        }
    } 

    public void placeArmoredBet()
    {
        if(betCheck <= 50 || betCheck >= 460)
        {
            GlobalCash.CashCount += betAmount;
            betText.GetComponent<Text>().text = "WIN!";
            plusCashText.GetComponent<Text>().text = "+ " + betAmount;
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            logText.GetComponent<Text>().text += ">Your armored chicken won! You gained " + betAmount + "\n";
            winSound.Play();
        }

        else
        {
            GlobalCash.CashCount -= betAmount;
            betText.GetComponent<Text>().text = "Your armored chicken died.";
            GlobalChickens.AChickenCount -= 1;
            lossCashText.GetComponent<Text>().text = "" + betAmount;
            lossCashText.GetComponent<Animation>().Play("lossCashAnim");
            logText.GetComponent<Text>().text += ">Your armored chicken died. You lost " + betAmount + "\n";
            loseSound.Play();
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
