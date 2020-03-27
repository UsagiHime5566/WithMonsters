using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{

    public void SetupGame(){
        playerData = SaveManager.Instance.LoadData();
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

    public void ExploreIncrease(){
        playerData.Explore += 1;
    }

    public void AddMonsterCatch(int index){
        if(playerData.collectList == null || index >= playerData.collectList.Count)
            return;

        playerData.collectList[index] += 1;
    }

    public void AddGold(int num){
        playerData.Gold += num;
    }

    public void SetTimeTick(long val){
        if(val > playerData.lastUpdateTimeTick)
            playerData.lastUpdateTimeTick = val;
    }

    public void SetSoundUse(bool val){
        playerData.DisableSound = !val;
    }

#region Get Game Data

    public int Get_Explore(){
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

    public bool Get_DisableSound(){
        return playerData.DisableSound;
    }
#endregion
}
