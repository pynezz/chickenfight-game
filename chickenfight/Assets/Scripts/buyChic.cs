using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyChic : MonoBehaviour
{
    public GlobalCash GCash;
    public GameObject plusCashText;
    public GameObject lossCashText;
    public AudioSource chicBak;
    //public GameObject logText;
    //public GameObject logPanel;
    public GameObject buyChickenBtn;
    public StatusAndStats StASt;
    public GameObject ArmChickBtn;

    public ActionLogManager ALM;
    public static string myText;
    public static Color myColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalCash.CashCount >= 5000)
        {
            ArmChickBtn.GetComponent<Image>().color = new Color32(59, 176, 75, 255);
        }
        else
        {
            ArmChickBtn.GetComponent<Image>().color = new Color32(176, 64, 59, 255);
        }
    }

    public void buyChick()
    {
        if(GlobalCash.CashCount >=50)
        {
            chicBak.Play();
            GlobalChickens.ChickenCount += 1;
            StatusAndStats.chickensBought += 1;
            GlobalCash.CashCount -= 50;
            plusCashText.GetComponent<Text>().text = "+ 1 Chicken";
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            
            myText = ">You bought a chicken";
            myColor = new Color32(233, 233, 233, 255);
            ALM.LogText(myText, myColor);
        }

        else if(GlobalCash.CashCount < 50)
        {
            
        }
    }

    public void buyArmChick()
    {
        if(GlobalCash.CashCount >= 5000)
        {
            GlobalChickens.AChickenCount += 1;
            StatusAndStats.chickensBought += 1;
            GlobalCash.CashCount -= 5000;
            plusCashText.GetComponent<Text>().text = "+ 1 Armored Chicken";
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            myText = ">You bought an Armored Chicken";
            myColor = new Color32(233, 233, 233, 255);
            ALM.LogText(myText, myColor);
        }

        else if(GlobalCash.CashCount < 5000)
        {

        }
    }
}
