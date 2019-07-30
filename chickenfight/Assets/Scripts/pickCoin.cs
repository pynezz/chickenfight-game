using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickCoin : MonoBehaviour
{

    public GlobalCash GCash;
    //public GameObject InformationPanel;
    public GameObject plusCashText;
    public GameObject logText;
    public GameObject logPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickCoin()
    {
        GlobalCash.CashCount += 1; 
        plusCashText.GetComponent<Text>().text = "+ 1";
        plusCashText.GetComponent<Animation>().Play("plusCashAnim");
        logText.GetComponent<Text>().text += ">You found a coin \n";

    }

}
