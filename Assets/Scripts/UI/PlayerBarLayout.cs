using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PlayerBarLayout : MonoBehaviour
{
    public Image StaminaBar;
    public TextMeshProUGUI StaminaValue;
    public TextMeshProUGUI GoldValue;
    public Image ExploreBar;
    public TextMeshProUGUI ExploreValue;

    float lastStaminaFillAmount;
    int lastGold;
    int stringTextGold = 0;

    void Start()
    {
        StartCoroutine(UpdateUI());
    }

    void Update(){
        GoldValue.text = stringTextGold.ToString();
    }

    WaitForSeconds waitUI = new WaitForSeconds(0.1f);
    IEnumerator UpdateUI(){
        while(true){
            yield return waitUI;

            ExploreBar.fillAmount = GameManager.Instance.Get_Explore()/100f;
            ExploreValue.text = GameManager.Instance.Get_Explore() + "%";

            float thisFillAmount = GameManager.Instance.Get_Stamina() / GameManager.Instance.Get_StaminaMax();
            if(lastStaminaFillAmount != thisFillAmount){
                lastStaminaFillAmount = thisFillAmount;
                // if(Mathf.Abs(lastStaminaFillAmount - thisFillAmount) < 2)
                //     StaminaBar.fillAmount = thisFillAmount;
                // else
                    StaminaBar.DOFillAmount(thisFillAmount, 0.5f);
            }
            StaminaValue.text = string.Format("{0}/{1}", GameManager.Instance.Get_Stamina().ToString("0"), GameManager.Instance.Get_StaminaMax().ToString("0"));

            int thisGold = GameManager.Instance.Get_Gold();
            if(lastGold != thisGold){
                lastGold = thisGold;
                DOTween.To(() => stringTextGold, x => stringTextGold = x, lastGold, 0.5f);
            }
        }
    }
}
