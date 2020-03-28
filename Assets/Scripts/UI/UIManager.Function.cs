using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public partial class UIManager : MonoBehaviour
{
    [Header("Runtime Option")]
    public PageLayout currentPage;
    public Button currentBTN;
    public void ToPage(PageLayout page){
        if(currentPage)
            currentPage.ClosePage();

        page.OpenPage();
        currentPage = page;
    }

    public void ToBTN(Button btn){
        if(currentBTN)
            currentBTN.interactable = true;

        btn.interactable = false;
        currentBTN = btn;
    }

    public void BTNClickFunction(PageLayout targetPage, Button targetBTN){
        ToPage(targetPage);
        ToBTN(targetBTN);
    }

    public void BTNClickGameStart(){
        //PageWelcome.canvasGroup.alpha = 0;
        PageWelcome.canvasGroup.DOFade(0, 1);
        PageWelcome.canvasGroup.blocksRaycasts = false;
        PageWelcome.GetComponent<CustomTween>()?.RunEnterTween();

        //Enter Game
        ToPage(PageMap);
        ToBTN(BTNMap);
        BackgroundShow(false);
    }
}
