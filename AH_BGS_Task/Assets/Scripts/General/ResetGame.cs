using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    [SerializeField] InventorySO inventorySO;
    [SerializeField] CustomizationInfosSO customizationInfosSO;
    [SerializeField] ItemInfosSO itemInfosSO;
    [SerializeField] Sprite head;
    [SerializeField] Sprite body;
    [SerializeField] Sprite sword;
    [SerializeField] ConsumableManager consumableManager;

    void ResetVariables() {
        for (int i = 0; i < inventorySO.ingredientInfos.Length; i++)
        {
            inventorySO.ingredientInfos[i].amount = 0;
        }
        customizationInfosSO.head = head;
        customizationInfosSO.body = body;
        customizationInfosSO.sword = sword;
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

        consumableManager.money.value = 200;
    }
}
