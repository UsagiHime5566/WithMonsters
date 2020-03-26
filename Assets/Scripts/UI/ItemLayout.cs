using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        TextName.text = data.ItemName;
        TextTip.text = data.ItemDesc;
        TextGold.text = data.CostGold.ToString();
    }
}
