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
    public GameObject fakeFightChickenBtn2;
    public AudioSource winSound;
    public AudioSource loseSound;
    public Slider betSlider;
    private float betCheck;

    public void Update()
    {
        betSlider.maxValue = GlobalCash.CashCount;
        betCheck = Random.Range(1, 1001);
        print(betCheck);
        if(betAmount > 50)
        {
            fakeFightChickenBtn2.SetActive(false);
        }
        else if(betAmount <= 50)
        {
            fakeFightChickenBtn2.SetActive(true);
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
            logText.GetComponent<Text>().text += ">You lost a chickenfight and lost a chicken and " + betAmount + "\n";
            loseSound.Play();
        }
    }


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
