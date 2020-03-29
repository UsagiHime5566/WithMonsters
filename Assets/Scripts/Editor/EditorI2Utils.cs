using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorI2Utils
{
    [MenuItem ("Custom/Language/English")]
    static void ToEnglish()
    {
        MyI2Utils.SetLanguage(SystemLanguage.English);
    }

    [MenuItem ("Custom/Language/Chinese")]
    static void ToChinese()
    {
        MyI2Utils.SetLanguage(SystemLanguage.ChineseTraditional);
    }
}
