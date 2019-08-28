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
    public GameObject fightChickenBtn, fightArmChickenBtn, bribeBtn, bribeBtnDisabled, chooseAnAmountBtn;
    public AudioSource winSound, loseSound;
    public Slider betSlider;
    private float betCheck;
    public float betAmount = 0;
    public Toggle ToggleArmChicken;

    public static string myText; //denne delen er for konsollen
    public static Color myColor; // ^

    public static bool bribe = false;
    public static int bribePrice = 50000;

    public static int fontSize;
    public static string animText; //denne delen er for å stacke animasjonene
    public static Color animColor; // -''-
    public static Animation plusLossAnim; // -''-

    public void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) && fightArmChickenBtn.activeSelf) && (betAmount > 50 && ToggleArmChicken.isOn))
        {
            placeArmoredBet();
        }
        else if((Input.GetKeyDown(KeyCode.Space) && fightChickenBtn.activeSelf) && betAmount > 50)
        {
            PlaceBet();
        }        

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
    public void AdjustBet(float newBet)
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
            myText = ">You won a chickenfight and won " + betAmount;
            myColor = new Color32(59, 192, 63, 255);
            ALM.LogText(myText, myColor);

            animText = "+" + betAmount;
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

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
            animText = "+" + betAmount;
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

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
            animText = "+" + betAmount;
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

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
            animText = "+" + betAmount;
            animColor = new Color32(59, 192, 63, 255);
            fontSize = 47;
            ALM.cashAnimation(animText, animColor, fontSize);

            myText = ">Your chicken won! You gained " + betAmount;
            myColor = new Color32(59, 192, 63, 255);
            ALM.LogText(myText, myColor);

            winSound.Play();
            betSlider.value = 0.1f;
        }

        else
        {
            GlobalCash.CashCount -= (betAmount);
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