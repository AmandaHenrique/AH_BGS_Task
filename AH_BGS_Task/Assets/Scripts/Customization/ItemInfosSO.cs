using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfosSO", menuName = "ScriptableObjects/ItemInfosSO")]
public class ItemInfosSO : ScriptableObject
{
    public SectionInfo[] sectionInfos;

    public Sprite GetSelectedPart(BodyPart bodyPart)
    {
        for (int i = 0; i < sectionInfos.Length; i++)
        {
            if (sectionInfos[i].bodyPart == bodyPart)
            {
                for (int j = 0; j < sectionInfos[i].itemInfos.Length; j++)
                {
                    if (sectionInfos[i].itemInfos[j].isSelected)
                    {
                        return sectionInfos[i].itemInfos[j].icon;
                    }
                }
            }
        }
        return null;
    }
}
 
[System.Serializable]
public class SectionInfo
{
    public string sectionName;
    public BodyPart bodyPart;
    public ItemInfo[] itemInfos;
}

[System.Serializable]
public class ItemInfo {
    public Sprite icon;
    public int price;
    public bool isUnlocked = false;
    public bool isSelected = false;
}