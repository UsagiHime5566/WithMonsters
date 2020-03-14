using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class UIManager : MonoBehaviour
{
    [Header("Welcome")]
    public WelcomePage PageWelcome; 
    public Button BTNGameStart;

    [Header("Page View")]
    public PageLayout PageMap;
    public PageLayout PageBag;
    public PageLayout PageCollect;
    public PageLayout PageSystem;

    [Header("Function Button")]
    public Button BTNMap;
    public Button BTNBag;
    public Button BTNCollect;
    public Button BTNSystem;



    // Start is called before the first frame update
    void Start()
    {
        BTNGameStart.onClick.AddListener(BTNClickGameStart);
        BTNMap.onClick.AddListener(delegate { BTNClickFunction(PageMap); });
        BTNBag.onClick.AddListener(delegate { BTNClickFunction(PageBag); });
        BTNCollect.onClick.AddListener(delegate { BTNClickFunction(PageCollect); });
        BTNSystem.onClick.AddListener(delegate { BTNClickFunction(PageSystem); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
