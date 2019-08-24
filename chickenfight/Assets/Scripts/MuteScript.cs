using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteScript : MonoBehaviour
{
    public GameObject muteBtnOn;
    public GameObject muteBtnOff;
    public GameObject welcomeMuteBtn;
    bool isMute; 

    public void Mute(bool isMuted)
    {
        muteBtnOn.SetActive(isMuted);
        welcomeMuteBtn.SetActive(isMuted);
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }

    public void MuteWelcomeScreen(bool wIsMuted)
    {

        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
}
