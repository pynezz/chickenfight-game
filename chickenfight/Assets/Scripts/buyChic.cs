using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyChic : MonoBehaviour
{
    public GlobalCash GCash;
    public GameObject plusCashText;
    public AudioSource chicBak;
    public GameObject logText;
    public GameObject logPanel;
    public GameObject buyChickenBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyChick()
    {
        if(GlobalCash.CashCount >=50)
        {
            chicBak.Play();
            GlobalChickens.ChickenCount += 1;
            GlobalCash.CashCount -= 50;
            plusCashText.GetComponent<Text>().text = "+ 1 Chicken";
            plusCashText.GetComponent<Animation>().Play("plusCashAnim");
            logText.GetComponent<Text>().text += "+1 Chicken \n";

        }

        else if(GlobalCash.CashCount < 50)
        {
            
        }

    }
}
