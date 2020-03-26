using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagLayout : MonoBehaviour
{
    public ItemLayout BTNStaminaRecover;
    public ItemLayout BTNStaminaMax;
    public ItemLayout BTNStaminaSpeed;
    public ItemLayout BTNMonsterStick;
    public string StringSoldOut = "售完";
    IEnumerator Start()
    {
        BTNStaminaRecover.BTNBuy.onClick.AddListener(OnStaminaRecover);
        BTNStaminaMax.BTNBuy.onClick.AddListener(OnStaminaMax);
        BTNStaminaSpeed.BTNBuy.onClick.AddListener(OnStaminaSpeed);
        BTNMonsterStick.BTNBuy.onClick.AddListener(OnMonsterStick);

        //Wait for playerData setup
        yield return null;

        CheckMonsterStickUse();
        StartCoroutine(ContinueUpdateButtonsActive());
    }

    WaitForSeconds wait = new WaitForSeconds(1);
    IEnumerator ContinueUpdateButtonsActive(){
        while (true)
        {
            yield return wait;

            ActiveBTNs();
        }
    }

    void OnStaminaRecover(){
        GameManager.Instance.AddGold(-BTNStaminaRecover.data.CostGold);
        GameManager.Instance.StaminaRecoverAll();
        ActiveBTNs();
    }
    void OnStaminaMax(){
        GameManager.Instance.AddGold(-BTNStaminaMax.data.CostGold);
        GameManager.Instance.StaminaMaxIncrease();
        ActiveBTNs();
    }
    void OnStaminaSpeed(){
        GameManager.Instance.AddGold(-BTNStaminaSpeed.data.CostGold);
        GameManager.Instance.StaminaSpeedIncrease();
        ActiveBTNs();
    }

    void OnMonsterStick(){
        GameManager.Instance.AddGold(-BTNMonsterStick.data.CostGold);
        GameManager.Instance.ExploreIncrease();
        ActiveBTNs();
        CheckMonsterStickUse();
    }

    void CheckMonsterStickUse(){
        if(GameManager.Instance.Get_Explore() < 100)
            return;

        BTNMonsterStick.BTNBuy.interactable = false;
        BTNMonsterStick.TextBTN.text = StringSoldOut;
        BTNMonsterStick.TextBTN.color = BTNMonsterStick.BTNBuy.colors.disabledColor;
    }

    void IsActiveBTN(ItemLayout item){
        if(GameManager.Instance.Get_Gold() < item.data.CostGold){
            item.BTNBuy.interactable = false;
            item.TextBTN.color = item.BTNBuy.colors.disabledColor;
        } else {
            item.BTNBuy.interactable = true;
            item.TextBTN.color = item.BTNBuy.colors.normalColor;
        }
    }

    void ActiveBTNs(){
        IsActiveBTN(BTNStaminaRecover);
        IsActiveBTN(BTNStaminaMax);
        IsActiveBTN(BTNStaminaSpeed);
        if(GameManager.Instance.Get_Explore() < 100)
            IsActiveBTN(BTNMonsterStick);
    }
}
