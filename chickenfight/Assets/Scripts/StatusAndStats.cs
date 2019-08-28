using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusAndStats : MonoBehaviour
{
    public GameObject fightsWonText, chickensBoughtText, chickensLostText, moneyLostText, moneyGainedText, StatusText, StatusBackground;
    public static int fightsWon;
    public static int chickensBought;
    public static int chickensLost;
    public static int moneyLost;
    public static float moneyGained;
    public static int marketPlaceUnlock;

    public string currentStatus;
    public GameObject MPUnlockBtn1, MPUnlockBtn2, MPUnlockBtn3, MPUnlockBtn4, MPUnlockBtn5;
    public GameObject MPUnlockBtn1text, MPUnlockBtn2text, MPUnlockBtn3text, MPUnlockBtn4text, MPUnlockBtn5text;
    public GameObject MPUnlockBtn1Disabled, MPUnlockBtn2Disabled, MPUnlockBtn3Disabled, MPUnlockBtn4Disabled, MPUnlockBtn5Disabled;
    public GameObject statsWindow;
    public GameObject levelText;

    public PurchaseLog PurchLog;

    public void openStats()
    {
        statsWindow.SetActive(!statsWindow.activeSelf);
    }

    void Update()
    {
        fightsWonText.GetComponent<Text>().text = "Fights won: " + fightsWon;
        chickensBoughtText.GetComponent<Text>().text = "Chickens bought: " + chickensBought;
        chickensLostText.GetComponent<Text>().text = "Chickens lost: " + chickensLost;
        moneyLostText.GetComponent<Text>().text = "Money lost: " + moneyLost;
        moneyGainedText.GetComponent<Text>().text = "Money gained: " + moneyGained;
        StatusText.GetComponent<Text>().text = currentStatus;

        if(fightsWon <= 25)
        {
            currentStatus = "Chicken Nugget";
            StatusBackground.GetComponent<Image>().color = new Color32(152, 55, 56, 255);
        }

        if((fightsWon > 25 && fightsWon <= 75) && moneyGained >= 10000)
        {
            currentStatus = "Chickapee";
            StatusBackground.GetComponent<Image>().color = new Color32(152, 55, 100, 255);
            levelText.GetComponent<Text>().text = ("Level 2");
            marketPlaceUnlock = 1;
        }

        if((fightsWon > 75 && fightsWon <= 200) && moneyGained >= 100000)
        {
            currentStatus = "Chocobo";
            StatusBackground.GetComponent<Image>().color = new Color32(137, 55, 152, 255);
            levelText.GetComponent<Text>().text = ("Level 3");
            marketPlaceUnlock = 2;
        }

        if((fightsWon > 200 && fightsWon <= 500) && moneyGained >= 500000)
        {
            currentStatus = "Ostrich";
            StatusBackground.GetComponent<Image>().color = new Color32(55, 78, 152, 255);
            levelText.GetComponent<Text>().text = ("Level 4");
            marketPlaceUnlock = 3;
        }

        if((fightsWon > 500 && fightsWon <= 1000) && moneyGained >= 1000000)
        {
            currentStatus = "Road Runner";
            StatusBackground.GetComponent<Image>().color = new Color32(55, 132, 152, 255);
            levelText.GetComponent<Text>().text = ("Level 5");
            marketPlaceUnlock = 4;
        }

        if((fightsWon > 1000 && fightsWon <= 2000) && moneyGained >= 5000000)
        {
            currentStatus = "War Emu";
            StatusBackground.GetComponent<Image>().color = new Color32(55, 152, 71, 255);
            levelText.GetComponent<Text>().text = ("Level 6");

            marketPlaceUnlock = 5;
        }

        switch(marketPlaceUnlock)
        {
            case 1:
                MPUnlockBtn1Disabled.SetActive(false);
                break;
            case 2:
                MPUnlockBtn2Disabled.SetActive(false);
                MPUnlockBtn2text.GetComponent<Text>().text = "Coming soon";
                break;
            case 3:
                MPUnlockBtn3Disabled.SetActive(false);
                MPUnlockBtn3text.GetComponent<Text>().text = "Coming soon";
                break;
            case 4:
                MPUnlockBtn4Disabled.SetActive(false);
                MPUnlockBtn4text.GetComponent<Text>().text = "Coming soon";
                break;
            case 5:
                MPUnlockBtn5Disabled.SetActive(false);
                MPUnlockBtn5text.GetComponent<Text>().text = "Coming soon";
                break;
            default:
                break;
        }
    }

    void Start()
    {

    }

}
