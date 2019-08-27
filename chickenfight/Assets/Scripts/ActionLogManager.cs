using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionLogManager : MonoBehaviour
{
    
    public GameObject actionText;

    private List<GameObject> textItems;

    void Start()
    {
        textItems = new List<GameObject>();
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
