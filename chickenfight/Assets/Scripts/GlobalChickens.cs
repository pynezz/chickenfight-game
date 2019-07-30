using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalChickens : MonoBehaviour
{
    public static int ChickenCount = 0;
    public GameObject chickensAmount;
    public GameObject fakeFightChickenBtn;
    public int InternalChickens;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InternalChickens = ChickenCount;
        chickensAmount.GetComponent<Text>().text = "CHICKENS: " + ChickenCount;

        if(ChickenCount > 0)
        {
            fakeFightChickenBtn.SetActive(false);
        }
        else if (ChickenCount <= 0)
        {
            fakeFightChickenBtn.SetActive(true);
        }

    }
}
