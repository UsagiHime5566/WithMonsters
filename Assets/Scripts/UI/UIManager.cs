using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public partial class UIManager : MonoBehaviour
{
    [Header("Welcome")]
    public WelcomePage PageWelcome; 
    public Button BTNGameStart;

    [Header("Page View")]
    public PageLayout HardwareRequirePage;
    public PageLayout PageMap;
    public PageLayout PageBag;
    public PageLayout PageCollect;
    public PageLayout PageSystem;
    public Image Background;
    public float bgFadeTimeConst = 0.5f;

    [Header("Function Button")]
    public Button BTNMap;
    public Button BTNBag;
    public Button BTNCollect;
    public Button BTNSystem;

    void Start()
    {
        BTNGameStart.onClick.AddListener(BTNClickGameStart);
        BTNMap.onClick.AddListener(delegate { BTNClickFunction(PageMap, BTNMap); BackgroundShow(false);});
        BTNBag.onClick.AddListener(delegate { BTNClickFunction(PageBag, BTNBag); BackgroundShow(true);});
        BTNCollect.onClick.AddListener(delegate { BTNClickFunction(PageCollect, BTNCollect); BackgroundShow(true);});
        BTNSystem.onClick.AddListener(delegate { BTNClickFunction(PageSystem, BTNSystem); BackgroundShow(true);});

        RequirePermissions.instance.OnNoPermission += delegate {
            HardwareRequirePage.OpenPage();
        };
    }

    void BackgroundShow(bool show){
        if(show)
            Background.DOFade(1, bgFadeTimeConst).SetAutoKill();
        else
            Background.DOFade(0, bgFadeTimeConst).SetAutoKill();
    }
}
