using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickCoin : MonoBehaviour
{

    public GlobalCash GCash;
    public StatusAndStats StASt;
    public GameObject plusCashText;
    public GameObject logText;
    public AudioSource pickCoinSound;

    public ActionLogManager ALM;
    public static string myText;
    public static Color myColor;
    public static int coinPickRate = 1;



    public void PickCoin()
    {
        GlobalCash.CashCount += coinPickRate;
        StatusAndStats.moneyGained += coinPickRate;
        plusCashText.GetComponent<Text>().text = "+ " + coinPickRate;
        plusCashText.GetComponent<Animation>().Play("plusCashAnim");
        myText = ">You found some cash!";
        myColor = new Color32(233, 233, 233, 255);
        ALM.LogText(myText, myColor);
        // logText.GetComponent<Text>().text += ">You found a coin \n";
        pickCoinSound.Play();
    }
}
