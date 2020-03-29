using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemLayout : MonoBehaviour
{
    public OptionCellLayout OptionSound;
    public OptionCellLayout OptionLanguage;
    public string stringEnable = "On";
    public string stringDisable = "Off";
    void Start()
    {
        OptionSound.BTNThis.onClick.AddListener(SwitchSound);
        OptionLanguage.BTNThis.onClick.AddListener(SwitchLanguage);
        UpdateOptionSoundUI();
        UpdateLanguageUI();
    }

    void SwitchSound(){
        if(GameManager.Instance.Get_DisableSound()){
            GameManager.Instance.SetSoundUse(true);
            
        } else {
            GameManager.Instance.SetSoundUse(false);
        }

        UpdateOptionSoundUI();
    }

    void SwitchLanguage(){
        if(GameManager.Instance.Get_Language() == SystemLanguage.English)
            GameManager.Instance.SetLanguage(SystemLanguage.ChineseTraditional);
        else
            GameManager.Instance.SetLanguage(SystemLanguage.English);

        UpdateLanguageUI();
        Debug.Log("Current Lang:" + GameManager.Instance.Get_Language().ToString());
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

    void UpdateLanguageUI(){
        MyI2Utils.SetLanguage(GameManager.Instance.Get_Language());
    }
}
