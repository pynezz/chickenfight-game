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

    public static bool bribe = false, noArmUpgrade = true;
    public static int bribePrice = 50000;

    public static int armChicWinChance = 510;
    public static int armChicUpgrade = 0;

    public static int fontSize;
    public static string animText; //denne delen er for å stacke animasjonene
    public static Color animColor; // -''-
    public static Animation plusLossAnim; // -''-

    public static int i = 0;
    public static int wins = 0;
    public static int loss = 0;

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

    public void Bribe() //flytt til purchaselog
    {
        if(GlobalCash.CashCount >= bribePrice)
        {
            bribe = true;
            GlobalCash.CashCount -= bribePrice;
            StatusAndStats.moneyGained += (int)betAmount;
            StatusAndStats.fightsWon++;
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
            StatusAndStats.fightsWon++;
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
            StatusAndStats.fightsWon++;
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
            bribeBtn.SetActive(true);
        }
    } 

    public void armoredChickenBet()
    {
        if (noArmUpgrade)
        {
            placeArmoredBet();
        }

        else if(!noArmUpgrade)
        {
            switch(armChicUpgrade)
            {
                case 1:
                    armChicWinChance = 512;
                    placeArmoredBet();
                    break;
                case 2:
                    armChicWinChance = 514;
                    placeArmoredBet();
                    break;
                case 3:
                    armChicWinChance = 516;
                    placeArmoredBet();
                    break;
                case 4:
                    armChicWinChance = 518;
                    placeArmoredBet();
                    break;
                case 5:
                    armChicWinChance = 520;
                     placeArmoredBet();
                    break;
                case 6:
                    armChicWinChance = 522;
                     placeArmoredBet();
                    break;
                case 7:
                    armChicWinChance = 524;
                    placeArmoredBet();
                    break;
                case 8:
                    armChicWinChance = 526;
                    placeArmoredBet();
                    break;
                case 9:
                    armChicWinChance = 528;
                    placeArmoredBet();
                    break;
                case 10:
                    armChicWinChance = 530;
                    placeArmoredBet();
                    break;
                case 11:
                    armChicWinChance = 532;
                    placeArmoredBet();
                    break;
                case 12:
                    armChicWinChance = 534;
                    placeArmoredBet();
                    break;
                case 13:
                    armChicWinChance = 536;
                    placeArmoredBet();
                    break;
                case 14:
                    armChicWinChance = 538;
                    placeArmoredBet();
                    break;
                case 15:
                    armChicWinChance = 540;
                    placeArmoredBet();
                    break;
                case 16:
                    armChicWinChance = 542;
                    placeArmoredBet();
                    break;
                case 17:
                    armChicWinChance = 544;
                    placeArmoredBet();
                    break;
                case 18:
                    armChicWinChance = 546;
                    placeArmoredBet();
                    break;
                case 19:
                    armChicWinChance = 548;
                    placeArmoredBet();
                    break;
                case 20:
                    armChicWinChance = 550;
                    placeArmoredBet();
                    break;
                default:
                    break;
            }
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

        else if (betCheck <= armChicWinChance)
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
}