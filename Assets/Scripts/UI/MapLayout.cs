using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapLayout : MonoBehaviour
{
    public Button BTNSLAM;
    public TextMeshProUGUI BTNText;
    public TextMeshProUGUI TextTip;
    public RectTransform unitPool;
    public Transform LookPoint;
    public float BornPos = 0.35f;
    public ParticleSystem BornEffect;
    public GameObject current;
    public string StringTip = "尚缺少 {0} 能量";

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
        MonsterUnit getUnit = GameManager.Instance.monsterPool.GetRandomUnit(GameManager.Instance.Get_Explore());
        current = Instantiate(getUnit.Unit3D, LookPoint);
        UnitAnim anim = current.GetComponent<UnitAnim>();
        DoStartTracking();

        //更新 使用者資料
        GameManager.Instance.CostStamina();
        GameManager.Instance.AddMonsterCatch(GameManager.Instance.monsterPool.ListPool.FindIndex(x => x == getUnit));
        GameManager.Instance.AddGold(getUnit.gold);

        //特效
        Instantiate(BornEffect, LookPoint.position + Vector3.up * 0.35f, Quaternion.identity);

        //Debug.Log("Create Monster with:" + getUnit.unitName);
    }

    void DoStartTracking(){
        VoidAR.GetInstance().startMarkerlessTracking();
    }

    void CheckButtonStats(){
        if(GameManager.Instance.CheckStamina()){
            BTNSLAM.interactable = true;
            BTNText.color = BTNSLAM.colors.normalColor;
            PopUpTextTip(false);
        } else {
            BTNSLAM.interactable = false;
            BTNText.color = BTNSLAM.colors.disabledColor;
            PopUpTextTip(true);
        }
    }

    void PopUpTextTip(bool val){
        if(val) {
            TextTip.color = new Color(1, 1, 1, 1);
            TextTip.text = string.Format(StringTip, GameManager.Instance.gameConstant.StaminaExploreCost - GameManager.Instance.Get_Stamina());
        }
        else
            TextTip.color = new Color(1, 1, 1, 0);
    }
}
