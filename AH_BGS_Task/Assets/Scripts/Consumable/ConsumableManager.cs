using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : Singleton<ConsumableManager>
{
    [Header("Consumables")]
    [Space]
    public Consumable money;

    public static Action OnValueChanged;
    public static Action<ConsumableType, float> OnIncrement;
    public static Action<ConsumableType, float> OnConsume;

    public static Action<float> OnMoneyCleaned;

    private void Start()
    {
        Setup();
    }

    public void Setup() {

        //money.Increment(DataManager.Instance.Player_Data.money);
        money.Increment(100);
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
}
