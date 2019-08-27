using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armoredChickenToggle : MonoBehaviour
{
    public GameObject fightArmChickenBtn;
    public GameObject chooseChicToFightBtn;
    public Toggle armChickenToggle;
    public GlobalChickens GChick;

    private static bool armChickCheck;

    private bool newValue;

    void Start()
    {
        
    }

    void Update()
    {
        if(armChickCheck && GlobalChickens.AChickenCount < 1)
        {
            armChickCheck = false;
            armChickenToggle.isOn = false;
        }
    }


    public void toggleArmChicken(bool newValue)
    {
        armChickCheck = true;
        fightArmChickenBtn.SetActive(newValue);
        chooseChicToFightBtn.SetActive(newValue);
    }
}
