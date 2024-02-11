using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/InventorySO")]
public class InventorySO : ScriptableObject
{
    public IngredientInfo[] ingredientInfos;

    public void RemoveIngredient(IngredientType ingredientType)
    {
        if(GetIngredient(ingredientType).amount > 0)
            GetIngredient(ingredientType).amount--;
    }
    public void AddIngredient(IngredientType ingredientType) {
        GetIngredient(ingredientType).amount++;
    }
    public IngredientInfo GetIngredient(IngredientType ingredientType)
    {
        for (int i = 0; i < ingredientInfos.Length; i++)
        {
            if (ingredientInfos[i].ingredientType == ingredientType)
                return ingredientInfos[i];
        }
        return null;
    }
}

[System.Serializable]
public class IngredientInfo
{
    public string ingredName;
    public Sprite icon;
    public IngredientType ingredientType;
    public int price;
    public int amount;
}