using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CanvasManager : Singleton<CanvasManager>
{
    public void OpenInventory() {
        InventoryUI.Instance.Show();
    }
}
