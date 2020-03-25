using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{

    public void SetupNewGame(){
        playerData = new PlayerData();
        playerData.Stamina = gameConstant.DefaultStaminaMax;
        playerData.Gold = gameConstant.DefaultGold;
    }

    public void CostStamina(){
        float stamina = gameConstant.StaminaExploreCost;
        if(playerData.Stamina < stamina)
            return;

        playerData.Stamina -= stamina;
    }

    public bool CheckStamina(){
        if(playerData.Stamina < gameConstant.StaminaExploreCost)
            return false;
        
        return true;
    }

    public void StaminaRecoverAll(){
        playerData.Stamina = Get_StaminaMax();
    }

    public void StaminaMaxIncrease(){
        playerData.PlusStaminaMax += 1;
    }

    public void StaminaSpeedIncrease(){
        playerData.PlusStaminaRecover += 1;
    }

    public void AddMonsterCatch(int index){
        if(playerData.collectList == null || index >= playerData.collectList.Count)
            return;

        playerData.collectList[index] += 1;
    }

#region Get Game Data

    public float Get_Explore(){
        return playerData.Explore;
    }

    public float Get_Stamina(){
        return playerData.Stamina;
    }

    public float Get_StaminaMax(){
        return gameConstant.DefaultStaminaMax + playerData.PlusStaminaMax * gameConstant.EachStaminaPlus;
    }

    public int Get_MonsterCollect(int index){
        return playerData.collectList[index];
    }

    public int Get_Gold(){
        return playerData.Gold;
    }
#endregion
}
