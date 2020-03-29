using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int Explore;
    public float Stamina;
    public int Gold;
    public int PlusStaminaMax;
    public int PlusStaminaRecover;
    public int ExploreStick;
    public List<int> collectList;
    public long lastUpdateTimeTick;
    
    //System option
    public bool DisableSound;
    public int languageCode;

    public PlayerData(){
        collectList = new List<int>();

        if(!GameManager.Instance)
            return;

        Stamina = GameManager.Instance.gameConstant.DefaultStaminaMax;
        Gold = GameManager.Instance.gameConstant.DefaultGold;

        int max = GameManager.Instance.gameConstant.MaxMonster;
        for (int i = 0; i < max; i++)
            collectList.Add(0);

    }
}
