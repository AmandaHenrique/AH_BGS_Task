using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InventoryUI_Restaurant : InventoryUI
{
    [SerializeField] TextMeshProUGUI sellMessage;
    [SerializeField] Button sellButton;
    IngredientInfo ingredientInfo;

    private void OnEnable()
    {
        IngredientUI.Select += UpdateSellMessage;
        sellMessage.text = $"Select an ingredient to sell";
        sellButton.interactable = false;
    }

    private void OnDisable()
    {
        IngredientUI.Select -= UpdateSellMessage;
    }

    void UpdateSellMessage(IngredientType ingredientType)
    {
        ingredientInfo = inventorySO.GetIngredient(ingredientType);

        if (ingredientInfo.amount <= 0)
        {
            sellMessage.text = $"you don't have enough {ingredientInfo.ingredName} to sell";
            sellButton.interactable = false;
        }
        else {
            sellMessage.text = $"sell {ingredientInfo.ingredName} for {ingredientInfo.price} coins?";
            sellButton.interactable = true;
        }

    }
    public void Done()
    {
        FadeScreen.Instance.FadeOut(LoadScene);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void Sell() {
        ingredientInfo.amount--;
        ConsumableManager.Instance.money.Increment(ingredientInfo.price);
        UpdateAll();
    }
}
