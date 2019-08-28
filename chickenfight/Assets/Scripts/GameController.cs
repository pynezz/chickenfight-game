using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text totalCashText;
    public Text totalChickensText;

    public float totalChickens = 0;
    public float work = 0;
    public float crime = 0;

    public Slider workSlider;
    public Slider crimeSlider;

    public GameObject workBtn;
    public GameObject crimeBtn;
    public GameObject fakeCrimeBtn;
    public GameObject fakeWorkBtn;
    public GameObject workBar, crimeBar;

    public static bool turnOffCrimeButton = false;
    public static bool turnOffWorkButton = false;

    void Start()
    {
        StartCoroutine(time());
        work = 50;
        crime = 30;
    }

    void Update()
    {
        workSlider.value = work;
        crimeSlider.value = crime;

        if(work >= 50){
            fakeWorkBtn.SetActive(false);
            workBtn.SetActive(true);
            workBar.GetComponent<Image>().color = new Color32(59, 192, 63, 255);
        }
        else if(work < 50){
            fakeWorkBtn.SetActive(true);
            workBtn.SetActive(false);
            workBar.GetComponent<Image>().color = new Color32(209, 112, 100, 255);
        }

        if (crime >= 30){
            fakeCrimeBtn.SetActive(false);
            crimeBtn.SetActive(true);
            crimeBar.GetComponent<Image>().color = new Color32(59, 192, 63, 255);
        }
        else if(crime < 30){
            fakeCrimeBtn.SetActive(true);
            crimeBtn.SetActive(false);
            crimeBar.GetComponent<Image>().color = new Color32(209, 112, 100, 255);
        }
    }

    private void timeAdd()
    {
        work += 1;
        crime += 1;
        // coin += 0.01f;
    }

    IEnumerator time()
    {
        while(true)
        {
            timeAdd();
            yield return new WaitForSeconds(1);
        }
    }
}

