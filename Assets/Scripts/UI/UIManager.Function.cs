using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //TODO Effect
        ToPage(targetPage);
        ToBTN(targetBTN);
    }

    public void BTNClickGameStart(){
        PageWelcome.canvasGroup.alpha = 0;
        PageWelcome.canvasGroup.blocksRaycasts = false;
        ToPage(PageMap);
        ToBTN(BTNMap);
    }
}
