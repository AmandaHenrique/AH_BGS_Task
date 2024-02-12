using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image[] icons;
    [SerializeField] TextMeshProUGUI priceTxt;
    [SerializeField] GameObject locked;
    [SerializeField] GameObject unlocked;
    [SerializeField] GameObject selected;
    ItemInfo info;
    BodyPart bodyPart;
    static Action<BodyPart> Select;

    private void OnEnable()
    {
        Select += UpdateSelection;
    }
    private void OnDisable()
    {
        Select -= UpdateSelection;
    }

    public void Setup(ItemInfo info, BodyPart bodyPart)
    {
        this.info = info;
        this.bodyPart = bodyPart;
        UpdateInfos();
    }

    public void UpdateInfos() {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].sprite = info.icon;
        }
        priceTxt.text = NumberFormatter.Format(info.price, NumberFormat.Value);

        locked.SetActive(false);
        unlocked.SetActive(false);
        selected.SetActive(false);

        if (info.isUnlocked) {
            unlocked.SetActive(true);
            if(info.isSelected)
                selected.SetActive(true);
        }
        else
            locked.SetActive(true);
    }

    public void Click() {
        if (!info.isUnlocked)
        {
            if (ConsumableManager.Instance.money.HasEnough(info.price))
            {
                ConsumableManager.Instance.money.Consume(info.price);
                info.isUnlocked = true;
                UpdateInfos();
            }
            else return;
        }
        else{
            CustomizationSystem.Instance.Customize(bodyPart, info.icon);
            Select?.Invoke(bodyPart);
            info.isSelected = true;
            UpdateInfos();
        }
    }

    public void UpdateSelection(BodyPart bodyPart) {
        if (this.bodyPart != bodyPart) return;
        info.isSelected = false;
        selected.SetActive(false);
    }
}
