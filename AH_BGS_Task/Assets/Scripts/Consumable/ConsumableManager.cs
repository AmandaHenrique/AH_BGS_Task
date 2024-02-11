using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsumableManager : SingletonDontDestroy<ConsumableManager>
{
    [Header("Consumables")]
    [Space]
    public Consumable money;
    [SerializeField] TextMeshProUGUI moneyTxt;

    public static Action OnValueChanged;
    public static Action<ConsumableType, float> OnIncrement;
    public static Action<ConsumableType, float> OnConsume;

    public static Action<float> OnMoneyCleaned;
    private void OnEnable()
    {
        OnValueChanged += UpdateCanvasInfos;
    }

    private void OnDisable()
    {
        OnValueChanged -= UpdateCanvasInfos;
    }

    private void Start()
    {
        UpdateCanvasInfos();
    }

    public Consumable GetConsumable(ConsumableType type)
    {
        switch (type)
        {
            case ConsumableType.Money:
                return money;
            default:
                return money;
        }
    }
    void UpdateCanvasInfos()
    {
        moneyTxt.text = NumberFormatter.Format(ConsumableManager.Instance.GetConsumable(ConsumableType.Money).value, NumberFormat.Value);
    }
}
