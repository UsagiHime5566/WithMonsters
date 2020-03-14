using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagLayout : MonoBehaviour
{
    public Button BTNStaminaRecover;
    public Button BTNStaminaMax;
    public Button BTNStaminaSpeed;
    public Button BTNMonsterStick;
    void Start()
    {
        BTNStaminaRecover.onClick.AddListener(OnStaminaRecover);
        BTNStaminaMax.onClick.AddListener(OnStaminaMax);
        BTNStaminaSpeed.onClick.AddListener(OnStaminaSpeed);
    }

    void OnStaminaRecover(){
        GameManager.Instance.StaminaRecoverAll();
    }
    void OnStaminaMax(){
        GameManager.Instance.StaminaMaxIncrease();
    }
    void OnStaminaSpeed(){
        GameManager.Instance.StaminaSpeedIncrease();
    }
}
