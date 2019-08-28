using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextLogItem : MonoBehaviour
{
    public void CashAnim(string animText, Color animColor, int fontSize) //animText = teksten som skal animeres. AnimColor er fargen på teksten.
    {
        GetComponent<Text>().text = animText;
        GetComponent<Text>().color = animColor;
        GetComponent<Text>().fontSize = fontSize;
    }
    public void SetText(string myText, Color myColor) //myText er teksten som skal skrives i konsollen. myColor er fargen på teksten i konsollen.
    {
        GetComponent<Text>().text = myText;
        GetComponent<Text>().color = myColor;
    }



}
