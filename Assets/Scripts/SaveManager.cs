using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    static SaveManager instance;
    public static SaveManager Instance {
        get {
            if(instance == null){
                instance = new SaveManager();
            }
            return instance;
        }
    }

    //Environment
    const string savePassword = "Artpower";
    const string saveFolder = "SaveData/";
    const string saveFormat = saveFolder + "player.dat";
    const string dateKey = "Save";

    ES3Settings es3Setting;

    public SaveManager () {
        es3Setting = new ES3Settings ();
        es3Setting.directory = ES3.Directory.PersistentDataPath;
    }

    public void SaveData (PlayerData data) {
        ES3.Save<PlayerData> (dateKey, data, saveFormat, es3Setting);
    }

    public PlayerData LoadData () {
        try {
            var data = new PlayerData();
            data = ES3.Load (dateKey, saveFormat, data, es3Setting);
            return data;
        } catch {}

        return null;
    }
    
}
