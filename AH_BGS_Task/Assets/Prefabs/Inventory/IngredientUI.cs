using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientUI : MonoBehaviour
{
    [SerializeField] Image[] icons;
    [SerializeField] TextMeshProUGUI amountTxt;
    [SerializeField] GameObject locked;
    [SerializeField] GameObject unlocked;
    [SerializeField] GameObject selected;
    IngredientInfo info;
    IngredientType ingredientType;
    public static Action<IngredientType> Select;
    bool isSelected = false;
    private void OnEnable()
    {
        Select += UpdateSelection;
    }
    private void OnDisable()
    {
        Select -= UpdateSelection;
    }

    public void Setup(IngredientInfo info)
    {
        this.info = info;
        ingredientType = info.ingredientType;
        UpdateInfos();
    }

    public void UpdateInfos()
    {
        if (info == null) return;

        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].sprite = info.icon;
        }
        amountTxt.text = NumberFormatter.Format(info.amount, NumberFormat.Value);

        locked.SetActive(false);
        selected.SetActive(false);

        if (info.amount <= 0)
        {
            locked.SetActive(true);        
        }
        if(isSelected)
            selected.SetActive(true);
    }

    public void Click()
    {
        Select?.Invoke(ingredientType);
        isSelected = true;
        selected.SetActive(true);
    }

    public void UpdateSelection(IngredientType ingredientType)
    {
        isSelected = false;
        UpdateInfos();
    }
}
