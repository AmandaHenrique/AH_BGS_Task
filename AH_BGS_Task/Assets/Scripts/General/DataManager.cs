using System;
using System.Collections;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField]
    public PlayerData Player_Data;
    public static Action OnLoaded;
    private string Save_Key = "SaveData";
    public bool gameQuit = false;

    private void Awake()
    {
        LoadData();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            SaveData();
    }

    private void OnApplicationQuit()
    {
        gameQuit = true;
        SaveData();
    }

    /// <summary>
    /// Saves Player Data with current values.
    /// </summary>
    public void SaveData()
    {
        // saves current time
        //Player_Data.lastLogin = DateTime.Now.ToString();

        // saves if there's a currently active boost
        //Player_Data.boostData = BoostManager.Instance.currentActiveBoost;
        UpdateData();

        // creates json string with current Player_Data info
        string json = JsonUtility.ToJson(Player_Data);

        // saves json into a Player Prefs key
        PlayerPrefs.SetString(Save_Key, json);
        PlayerPrefs.Save();
    }

    public void UpdateData()
    {
        Player_Data.money = ConsumableManager.Instance.money.value;
    }


    /// <summary>
    /// Loads all saved data.
    /// </summary>
    public void LoadData()
    {
        Player_Data = new PlayerData();

        if (PlayerPrefs.HasKey(Save_Key))
        {
            Player_Data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(Save_Key));
        }
        else
        {
            Player_Data.money = 0;
        }

        OnLoaded?.Invoke();
    }

    /*public void ToggleSounds()
    {
        Player_Data.soundsOn = !Player_Data.soundsOn;
        AudioManager.Instance.MuteAudio(!Player_Data.soundsOn);
    }*/
}

[System.Serializable()]
public class PlayerData
{
    public float money = 0;
    public bool soundsOn = true;
}