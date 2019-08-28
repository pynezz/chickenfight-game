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
    public static string animText;
    public static Color animColor;
    public static Animation plusLossAnim;
    public GameObject plusLossText;
    public static int fontSize;
    public void PickCoin()
    {
        GlobalCash.CashCount += coinPickRate;
        StatusAndStats.moneyGained += coinPickRate;
        myText = ">You found some cash!";
        myColor = new Color32(233, 233, 233, 255);
        ALM.LogText(myText, myColor);
        pickCoinSound.Play();
        animText = "+" + coinPickRate;
        animColor = new Color32(59, 192, 63, 255);
        fontSize = 47;
        ALM.cashAnimation(animText, animColor, fontSize);
    }
}
