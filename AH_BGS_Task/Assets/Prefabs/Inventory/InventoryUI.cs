using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] protected InventorySO inventorySO;
    [SerializeField] IngredientUI ingredientUIPrefab;
    [SerializeField] GameObject container;
    [SerializeField] Transform content;
    IngredientUI[] ingredientUIs;

    void Start()
    {
        ingredientUIs = new IngredientUI[inventorySO.ingredientInfos.Length];
        for (int i = 0; i < inventorySO.ingredientInfos.Length; i++)
        {
            IngredientUI go = Instantiate(ingredientUIPrefab.gameObject, content).GetComponent<IngredientUI>();
            go.Setup(inventorySO.ingredientInfos[i]);
            ingredientUIs[i] = go;
        }
    }

    protected void UpdateAll()
    {
        for (int i = 0; i < ingredientUIs.Length; i++)
        {
            ingredientUIs[i].UpdateInfos();
        }
    }

    public void Show()
    {
        container.SetActive(true);
        UpdateAll();
    }
    public void Close()
    {
        container.SetActive(false);
    }
}
