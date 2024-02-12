using System;
using System.Collections;
using UnityEngine;

public class DataManager : SingletonDontDestroy<DataManager>
{
    [SerializeField]
    public PlayerData Player_Data;
    public static Action OnLoaded;
    private string Save_Key = "SaveData_Prototype";
    bool gameQuit = false;

    [SerializeField] InventorySO inventorySO;
    [SerializeField] CustomizationInfosSO customizationInfosSO;
    [SerializeField] ConsumableManager consumableManager;
    [SerializeField] ItemInfosSO itemInfosSO;

    [SerializeField] Sprite head;
    [SerializeField] Sprite body;
    [SerializeField] Sprite sword;

    protected override void Awake()
    {
        base.Awake();
        LoadData();
    }
    /*private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            SaveData();
    }

    private void OnApplicationQuit()
    {
        gameQuit = true;
        SaveData();
    }*/

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
        Player_Data.money = consumableManager.money.value;
        Player_Data.sectionInfos = itemInfosSO.sectionInfos;
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
            itemInfosSO.sectionInfos = Player_Data.sectionInfos;

            customizationInfosSO.head = itemInfosSO.GetSelectedPart(BodyPart.Head);
            customizationInfosSO.body = itemInfosSO.GetSelectedPart(BodyPart.Body);
            customizationInfosSO.sword = itemInfosSO.GetSelectedPart(BodyPart.Sword);

            ConsumableManager.Instance.money.value = Player_Data.money;

        }
        else
        {
            ConsumableManager.Instance.money.value = 200;
            for (int i = 0; i < itemInfosSO.sectionInfos.Length; i++)
            {
                for (int j = 0; j < itemInfosSO.sectionInfos[i].itemInfos.Length; j++)
                {
                    itemInfosSO.sectionInfos[i].itemInfos[j].isSelected = false;
                    itemInfosSO.sectionInfos[i].itemInfos[j].isUnlocked = false;
                }
            }
            itemInfosSO.sectionInfos[0].itemInfos[0].isUnlocked = true;
            itemInfosSO.sectionInfos[1].itemInfos[0].isUnlocked = true;
            itemInfosSO.sectionInfos[2].itemInfos[0].isUnlocked = true;

            itemInfosSO.sectionInfos[0].itemInfos[0].isSelected = true;
            itemInfosSO.sectionInfos[1].itemInfos[0].isSelected = true;
            itemInfosSO.sectionInfos[2].itemInfos[0].isSelected = true;

            customizationInfosSO.head = head;
            customizationInfosSO.body = body;
            customizationInfosSO.sword = sword;
        }

        OnLoaded?.Invoke();
    }
}

[System.Serializable()]
public class PlayerData
{
    public float money = 0;
    public SectionInfo[] sectionInfos;
}
