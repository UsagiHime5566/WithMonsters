using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISounds : MonoBehaviour
{
    public enum UISoundList
    {
        SDGameStart,
        SDExplore,
        SDBTN,
        SDBuy,
        SDSwitch
    }
    public static UISounds instance;
    public AudioClip SDGameStart;
    public AudioClip SDExplore;
    public AudioClip SDBTN;
    public AudioClip SDBuy;
    public AudioClip SDSwitch;
    public AudioMixer audioMixer;
    
    AudioSource audioSource;
    
    void Awake(){
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySound(UISoundList label){
        switch (label)
        {
            case UISoundList.SDGameStart:
                mPlay(SDGameStart);
                break;
            case UISoundList.SDExplore:
                mPlay(SDExplore);
                break;
            case UISoundList.SDBTN:
                mPlay(SDBTN);
                break;
            case UISoundList.SDBuy:
                mPlay(SDBuy);
                break;
            case UISoundList.SDSwitch:
                mPlay(SDSwitch);
                break;
        }
    }

    void mPlay(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }

    public void SetMixerVolume(float val){
        audioMixer.SetFloat("Master", val);
    }
}
