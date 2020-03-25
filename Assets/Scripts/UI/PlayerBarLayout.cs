using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBarLayout : MonoBehaviour
{
    public Image StaminaBar;
    public TextMeshProUGUI StaminaValue;
    public TextMeshProUGUI GoldValue;
    public Image ExploreBar;
    public TextMeshProUGUI ExploreValue;

    void Start()
    {
        StartCoroutine(UpdateUI());
    }

    WaitForSeconds waitUI = new WaitForSeconds(0.1f);
    IEnumerator UpdateUI(){
        while(true){
            yield return waitUI;

            ExploreBar.fillAmount = GameManager.Instance.Get_Explore();
            ExploreValue.text = ExploreBar.fillAmount.ToString("0.00") + "%";

            StaminaBar.fillAmount = GameManager.Instance.Get_Stamina() / GameManager.Instance.Get_StaminaMax();
            StaminaValue.text = string.Format("{0}/{1}", GameManager.Instance.Get_Stamina().ToString("0"), GameManager.Instance.Get_StaminaMax().ToString("0"));

            GoldValue.text = GameManager.Instance.Get_Gold().ToString();
        }
    }
}
