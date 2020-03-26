using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapLayout : MonoBehaviour
{
    public Button BTNSLAM;
    public TextMeshProUGUI BTNText;
    public RectTransform unitPool;
    public RectTransform prefabDummy;
    public RectTransform current;
    public GameObject prefab3DUnit;
    public Transform LookPoint;

    private void Start() {
        BTNSLAM.onClick.AddListener(OnSLAM);
        StartCoroutine(CheckStaminaEnough());
    }

    WaitForSeconds wait = new WaitForSeconds(0.5f);
    IEnumerator CheckStaminaEnough(){
        while(true){
            yield return wait;

            CheckButtonStats();
        }
    }

    void OnSLAM(){
        if(!GameManager.Instance.CheckStamina())
            return;

        CheckButtonStats();

        if(current)
            Destroy(current.gameObject);

        //設置 SLAM
        MonsterUnit getUnit = GameManager.Instance.monsterPool.GetRandomUnit();
        current = Instantiate(prefabDummy, unitPool);
        current.GetComponent<Image>().sprite = getUnit.icon;

        //更新 使用者資料
        GameManager.Instance.CostStamina();
        GameManager.Instance.AddMonsterCatch(GameManager.Instance.monsterPool.ListPool.FindIndex(x => x == getUnit));
        GameManager.Instance.AddGold(getUnit.gold);

        Debug.Log("Create Monster with:" + getUnit.unitName);
    }

    void CheckButtonStats(){
        if(GameManager.Instance.CheckStamina()){
            BTNSLAM.interactable = true;
            BTNText.color = BTNSLAM.colors.normalColor;
        } else {
            BTNSLAM.interactable = false;
            BTNText.color = BTNSLAM.colors.disabledColor;
        }
    }
}
