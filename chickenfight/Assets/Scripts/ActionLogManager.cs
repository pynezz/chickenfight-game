using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionLogManager : MonoBehaviour
{    
    public GameObject actionText; //her kobles konsolltekstobjektet på i Unity
    public GameObject animText; //her kobles tekstobjektet som vil bli animert på i Unity

    private List<GameObject> textAnims; //her defineres listen som skal brukes senere i scriptet
    private List<GameObject> textItems; // ^
    void Start()
    {
        textItems = new List<GameObject>(); //en liste av GameObjects for konsolltekster
        textAnims = new List<GameObject>(); //en liste av GameObjects for animasjoner
    }
    public void cashAnimation(string lossWinCashString, Color cashAnimColor, int fontSize)//, Animation lossPlusAnimation)
    {
        if(textAnims.Count == 10) //mengden objekter som skal genereres, når det er 10 objekter vil if statementen kjøre
        {
            GameObject tempAnim = textAnims[0]; //her genereres et objekt som heter tempAnim som index 0 i listen textAnims
            Destroy(tempAnim.gameObject); //her slettes objektet 
            textAnims.Remove(tempAnim); //her fjernes objektet fra listen. Dette er for å starte listen på nytt fra bunnen av
        }

        GameObject newAnim = Instantiate(animText) as GameObject; //her laget et nytt objekt i listen animText
        newAnim.SetActive(true); //her settes objektet aktivt/synlig
        newAnim.GetComponent<TextLogItem>().CashAnim(lossWinCashString, cashAnimColor, fontSize); //her henter objektet variabler fra TextLogItemskriptet og i funksjonen CashAnim
        newAnim.transform.SetParent(animText.transform.parent, false); //her settes objektet som barn av tekstobjektet animText sin forelder
        textAnims.Add(newAnim.gameObject); //her genereres legges objektet til i listen textAnims
    }
    public void LogText(string newTextString, Color newColor)
    {
        if(textItems.Count == 10)
        {
            GameObject tempItem = textItems[0];
            Destroy(tempItem.gameObject);
            textItems.Remove(tempItem);
        }
        GameObject newText = Instantiate(actionText) as GameObject;
        newText.SetActive(true);
        newText.GetComponent<TextLogItem>().SetText(newTextString, newColor);
        newText.transform.SetParent(actionText.transform.parent, false);
        textItems.Add(newText.gameObject);
    }
}
