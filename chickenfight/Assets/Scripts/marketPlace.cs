using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class marketPlace : MonoBehaviour, IPointerEnterHandler
{

    public GameObject MarketPlaceCanvas;

    public void enableMarket()
    {
        MarketPlaceCanvas.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            disableMarket();
        }
    }

    public void disableMarket()
    {
        MarketPlaceCanvas.SetActive(false);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {

    }
}