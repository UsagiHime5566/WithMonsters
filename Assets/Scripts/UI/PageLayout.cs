using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class PageLayout : MonoBehaviour
{
    [HideInInspector] public CanvasGroup canvasGroup;
    [HideInInspector] public List<CustomTween> tweens;
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
        tweens = new List<CustomTween>(GetComponentsInChildren<CustomTween>());
    }

    public void OpenPage(){
        //canvasGroup.alpha = 1;
        canvasGroup.DOFade(1, 0.2f);
        canvasGroup.blocksRaycasts = true;

        if(tweens == null)
            return;
        
        foreach (var item in tweens)
        {
            item.RunEnterTween();
        }
    }

    public void ClosePage(){
        //canvasGroup.alpha = 0;
        canvasGroup.DOFade(0, 0.2f);
        canvasGroup.blocksRaycasts = false;

        if(tweens == null)
            return;
        
        foreach (var item in tweens)
        {
            item.RunExitTween();
        }
    }
}
