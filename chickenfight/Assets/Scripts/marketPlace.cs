using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class marketPlace : MonoBehaviour
{

    public GameObject MarketPlaceCanvas;

    public void enableMarket()
    {
        MarketPlaceCanvas.SetActive(true);
    }

    public void disableMarket()
    {
        MarketPlaceCanvas.SetActive(false);
    }
}