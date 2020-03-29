using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using I2.Loc;

[CreateAssetMenu]
public class ShopItem : ScriptableObject
{
    public string ItemName;
    public string ItemDesc;
    public LocalizedString TermName;
    public LocalizedString TermDesc;
    public int CostGold;
}
