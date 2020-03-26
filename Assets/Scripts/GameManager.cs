using System;
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
    public PlayerData playerData;
    public long currentTime;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
        SetupGame();
    }

    void Start()
    {
        StartCoroutine(StaminaRecover());
    }

    WaitForSeconds staminaWait = new WaitForSeconds(1.0f);
    IEnumerator StaminaRecover(){
        while(true){
            yield return staminaWait;

            //Check Timespan
            currentTime = GetCurrentTime();
            long span = currentTime - playerData.lastUpdateTimeTick;

            //Get span of seconds
            long second = Convert.ToInt64(new TimeSpan(span).TotalSeconds);
            if(second > 10) Debug.Log("Recover sec: " + second);

            //setting playerData Time tick
            SetTimeTick(currentTime);

            float recoverValue = second * (gameConstant.StaminaRecover + playerData.PlusStaminaRecover * gameConstant.EachStaminaRecover);
            playerData.Stamina = Mathf.Min(playerData.Stamina + recoverValue, Get_StaminaMax());

            SaveManager.Instance.SaveData(playerData);
             
        }
    }


    public static long GetCurrentTime(){
        DateTime t = GetLocalTime();
        return t.Ticks;
    }

    public static DateTime GetLocalTime(){
        DateTime t = new DateTime();
        try {
            t = DateTime.Now;
        } catch {
            t = DateTime.UtcNow;
        }
        return t;
    }

}
