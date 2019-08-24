using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armoredChickenToggle : MonoBehaviour
{
    public GameObject fightArmChickenBtn;
    public GameObject chooseChicToFightBtn;
    public GameObject testText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void toggleArmChicken(bool newValue)
    {
        fightArmChickenBtn.SetActive(newValue);
        chooseChicToFightBtn.SetActive(newValue);
    }
}
