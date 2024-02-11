using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] TextMeshProUGUI moneyTxt;
    private void OnEnable()
    {
        ConsumableManager.OnValueChanged += UpdateCanvasInfos;
    }

    private void OnDisable()
    {
        ConsumableManager.OnValueChanged -= UpdateCanvasInfos;
    }

    void UpdateCanvasInfos() {
        moneyTxt.text = NumberFormatter.Format(ConsumableManager.Instance.GetConsumable(ConsumableType.Money).value, NumberFormat.Value);
    }
}
