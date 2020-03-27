using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemLayout : MonoBehaviour
{
    public OptionCellLayout OptionSound;
    public string stringEnable = "On";
    public string stringDisable = "Off";
    void Start()
    {
        OptionSound.BTNThis.onClick.AddListener(SwitchSound);
        UpdateOptionSoundUI();
    }

    void SwitchSound(){
        if(GameManager.Instance.Get_DisableSound()){
            GameManager.Instance.SetSoundUse(true);
            
        } else {
            GameManager.Instance.SetSoundUse(false);
        }

        UpdateOptionSoundUI();
    }

    void UpdateOptionSoundUI(){
        if(GameManager.Instance.Get_DisableSound()){
            OptionSound.TextInfo.text = stringDisable;
            UISounds.instance.SetMixerVolume(-80);
        } else {
            OptionSound.TextInfo.text = stringEnable;
            UISounds.instance.SetMixerVolume(0);
        }
    }
}
