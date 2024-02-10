using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Consumable
{
    public float value;
    public ConsumableType type;

    public void Increment(float _value)
    {
        value += _value;
        ConsumableManager.OnValueChanged?.Invoke();
        ConsumableManager.OnIncrement?.Invoke(type, _value);
    }

    public void Consume(float _value)
    {
        if (HasEnough(_value)) {
            value -= _value;
            ConsumableManager.OnValueChanged?.Invoke();
            ConsumableManager.OnConsume?.Invoke(type, _value);
        }
        else { 
            //
        }
    }

    /// <summary>
    /// Returns if player has enough money based on _value
    /// </summary>
    /// <param name="_value">Amount of money to compare.</param>
    /// <returns></returns>
    public bool HasEnough(float _value) { 
        return value >= _value;
    }
}
