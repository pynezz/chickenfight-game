using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalChickens : MonoBehaviour
{
    public static int ChickenCount = 0;
    public static int AChickenCount = 0;

    public GameObject chickensAmount;
    public GameObject AChickensAmount;
    public GameObject marketPlaceAChicAmount;

    public Button chooseAnAmountBtn;
    public Button armoredFightChickenBtn;
    public Button fightChickenBtn;
    public Button chooseChickenBtn;
    public Button buyChicToFightBtn;

    public Toggle AChickenToggle;

    public int InternalChickens;

    void Start()
    {
        
    }

    void Update()
    {
        InternalChickens = ChickenCount + AChickenCount;
        chickensAmount.GetComponent<Text>().text = "CHICKENS: " + ChickenCount;
        AChickensAmount.GetComponent<Text>().text = "ARMORED CHICKENS: " + AChickenCount;
        marketPlaceAChicAmount.GetComponent<Text>().text = "YOU HAVE: " + AChickenCount;

        if (InternalChickens > 0)
        {
            chooseChickenBtn.gameObject.SetActive(false);
            buyChicToFightBtn.gameObject.SetActive(false);
            fightChickenBtn.gameObject.SetActive(true);
        }
        else if (InternalChickens == 0)
            buyChicToFightBtn.gameObject.SetActive(true);

        if((AChickenCount > 0 && !AChickenToggle.isOn) && ChickenCount < 1) 
        {
            chooseChickenBtn.gameObject.SetActive(true);
        }

        else if (AChickenCount == 0)
        {
            chooseChickenBtn.gameObject.SetActive(false);
        }

        if(AChickenCount == 0)
        {
            armoredFightChickenBtn.gameObject.SetActive(false);
        }

        if(ChickenCount == 0)
        {
            fightChickenBtn.gameObject.SetActive(false);
        }
    }
}
