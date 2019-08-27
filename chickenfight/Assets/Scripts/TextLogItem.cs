using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLogItem : MonoBehaviour
{
    public string myText1;
    public string myText2;
    public string myText3;
    public string myText4;

    public void SetText(string myText, Color myColor)
    {
        myText1 = myText;
        myText2 = myText;
        myText3 = myText;
        myText4 = myText;
        GetComponent<Text>().text = myText;
        GetComponent<Text>().color = myColor;
    }

}
