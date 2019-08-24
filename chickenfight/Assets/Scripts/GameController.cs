using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text totalCashText;
    public Text totalChickensText;

    //public float totalCash = 0;
    public float totalChickens = 0;

    public float work = 0;
    public float crime = 0;

    public Slider workSlider;
    public Slider crimeSlider;

    public GameObject workBtn;
    public GameObject crimeBtn;
    public GameObject fakeCrimeBtn;
    public GameObject fakeWorkBtn;

    public static bool turnOffCrimeButton = false;
    public static bool turnOffWorkButton = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(time());
        work = 50;
        crime = 30;
    }

    // Update is called once per frame
    void Update()
    {
        workSlider.value = work;
        crimeSlider.value = crime;

        if(work >= 50)
        {
            fakeWorkBtn.SetActive(false);
            workBtn.SetActive(true);
        }
        else if(work < 50)
        {
            fakeWorkBtn.SetActive(true);
            workBtn.SetActive(false);
        }

        if (crime >= 30)
        {
            fakeCrimeBtn.SetActive(false);
            crimeBtn.SetActive(true);
        }
        else if(crime < 30)
        {
            fakeCrimeBtn.SetActive(true);
            crimeBtn.SetActive(false);
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

