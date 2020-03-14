using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PageLayout : MonoBehaviour
{
    [HideInInspector] public CanvasGroup canvasGroup;
    public bool DoInitialize = true;

    [Header("Editor Switch")]
    public bool visible = false;

    #if UNITY_EDITOR
    private void OnValidate() {
        if(visible)
            GetComponent<CanvasGroup>().alpha = 1;
        else
            GetComponent<CanvasGroup>().alpha = 0;
    }
    #endif

    void Awake(){
        canvasGroup = GetComponent<CanvasGroup>();

        if(!DoInitialize)
            return;

        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPage(){
        //TODO
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public void ClosePage(){
        //TODO
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
