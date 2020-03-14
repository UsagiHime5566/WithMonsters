using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static PlayerData PlayerDataIns {
        get { return Instance.playerData; }
    }

    [Header("Scriptable Object")]
    public GameConstant gameConstant;
    public MonsterPool monsterPool;

    [Header("Runtime Variable")]
    public bool isNewGame = true;
    public PlayerData playerData;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(StaminaRecover());

        if(!isNewGame)
            return;
        SetupNewGame();
    }

    WaitForSeconds staminaWait = new WaitForSeconds(1.0f);
    IEnumerator StaminaRecover(){
        while(true){
            yield return staminaWait;

            float recoverValue = gameConstant.StaminaRecover + playerData.PlusStaminaRecover * gameConstant.EachStaminaRecover;
            playerData.Stamina = Mathf.Min(playerData.Stamina + recoverValue, Get_StaminaMax());
             
        }
    }

}
