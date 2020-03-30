using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using I2.Loc;

public static class MyI2Utils {

    public static string GetLanguageName (SystemLanguage language) {
        switch (language) {
            case SystemLanguage.ChineseTraditional:
                return "Chinese (Traditional)";
            case SystemLanguage.ChineseSimplified:
                return "Chinese (Simplified)";
            case SystemLanguage.English:
                return "English";
            case SystemLanguage.Japanese:
                return "Japanese";
            case SystemLanguage.Korean:
                return "Korean";
        }
        return "Chinese (Traditional)";
    }

    public static void SetLanguage (SystemLanguage language) {
        SetLanguage (GetLanguageName (language));
    }

    public static void SetLanguage (string language) {
        if (LocalizationManager.HasLanguage (language)) {
            LocalizationManager.CurrentLanguage = language;
            LocalizationManager.LocalizeAll ();
        }
    }

    public static SystemLanguage GetDefaultLanguage(){
        if(Application.systemLanguage == SystemLanguage.Chinese)
            return SystemLanguage.ChineseTraditional;
        if(Application.systemLanguage == SystemLanguage.ChineseTraditional)
            return SystemLanguage.ChineseTraditional;
        
        return SystemLanguage.English;
    }
}