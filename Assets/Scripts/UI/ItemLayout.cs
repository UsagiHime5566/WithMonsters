using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using I2.Loc;

public class ItemLayout : MonoBehaviour
{
    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextGold;
    public TextMeshProUGUI TextTip;
    public TextMeshProUGUI TextBTN;
    public Button BTNBuy;
    public ShopItem data;
    void Start()
    {
        if(data == null)
            return;

        //TextName.text = data.TermName.ToString();
        //TextTip.text = data.TermDesc.ToString();
        TextName.GetComponent<Localize>().SetTerm(data.TermName.mTerm);
        TextTip.GetComponent<Localize>().SetTerm(data.TermDesc.mTerm);
        TextGold.text = data.CostGold.ToString();
    }
}
