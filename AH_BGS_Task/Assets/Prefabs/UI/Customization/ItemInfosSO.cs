using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfosSO", menuName = "ScriptableObjects/ItemInfosSO")]
public class ItemInfosSO : ScriptableObject
{
    public SectionInfo[] sectionInfos;
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