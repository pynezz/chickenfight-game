using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    public GameObject welcomePanel;
    public GameObject tutorialPanel1;
    public GameObject tutorialPanel2;
    public GameObject tutorialPanel3;
    public GameObject tutorialPanel4;

    public void SkipTutorial()
    {
        welcomePanel.SetActive(false);
    }

    public void StartTutorial()
    {
        welcomePanel.SetActive(false);
        tutorialPanel1.SetActive(true);
    }

    public void TutorialStep2()
    {
        tutorialPanel1.SetActive(false);
        tutorialPanel2.SetActive(true);
    }

    public void TutorialStep3()
    {
        tutorialPanel2.SetActive(false);
        tutorialPanel3.SetActive(true);
    }

    public void TutorialStep4()
    {
        tutorialPanel3.SetActive(false);
        tutorialPanel4.SetActive(true);
    }

    public void EndTutorial()
    {
        tutorialPanel1.SetActive(false);
        tutorialPanel2.SetActive(false);
        tutorialPanel3.SetActive(false);
        tutorialPanel4.SetActive(false);
    }
}
