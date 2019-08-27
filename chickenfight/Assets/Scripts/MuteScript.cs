using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteScript : MonoBehaviour
{
    public GameObject muteBtnOff;
    public GameObject musicMuteOff;
    public GameObject welcomeMuteBtn;
    public GameObject Sounds;
    public GameObject Music;

    public void MuteAudio()
    {
        Sounds.SetActive(!Sounds.activeSelf);
        muteBtnOff.SetActive(!muteBtnOff.activeSelf);
    }

    public void MuteMusic()
    {
        Music.SetActive(!Music.activeSelf);
        musicMuteOff.SetActive(!musicMuteOff.activeSelf);
    }
}
