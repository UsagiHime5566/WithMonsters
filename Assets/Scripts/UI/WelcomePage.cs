using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class WelcomePage : MonoBehaviour
{
    [HideInInspector] public CanvasGroup canvasGroup;
    public TextMeshProUGUI TextVersion;
    public bool DoInitialize = true;
    void Awake(){
        canvasGroup = GetComponent<CanvasGroup>();

        if(!DoInitialize)
            return;

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    void Start(){
        TextVersion.text = "v" + Application.version;
    }
}
