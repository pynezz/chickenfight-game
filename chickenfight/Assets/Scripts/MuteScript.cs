using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteScript : MonoBehaviour
{
    public GameObject muteBtnOff, musicMuteOff;
    public GameObject muteBtnOffWS, musicMuteOffWS;
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

    public void MuteAudioWS()
    {
        Sounds.SetActive(!Sounds.activeSelf);
        muteBtnOffWS.SetActive(!muteBtnOffWS.activeSelf);
    }

    public void MuteMusicWS()
    {
        Music.SetActive(!Music.activeSelf);
        musicMuteOffWS.SetActive(!musicMuteOffWS.activeSelf);
    }
}
