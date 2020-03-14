using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIManager : MonoBehaviour
{
    [Header("Runtime Option")]
    public PageLayout currentPage;
    public void ToPage(PageLayout page){
        if(currentPage)
            currentPage.ClosePage();

        page.OpenPage();
        currentPage = page;
    }

    public void BTNClickFunction(PageLayout targetPage){
        //TODO Effect
        ToPage(targetPage);
    }

    public void BTNClickGameStart(){
        PageWelcome.canvasGroup.alpha = 0;
        PageWelcome.canvasGroup.blocksRaycasts = false;
        ToPage(PageMap);
    }
}
