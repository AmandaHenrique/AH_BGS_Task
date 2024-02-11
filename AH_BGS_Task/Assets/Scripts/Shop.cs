using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    [SerializeField] Shopkeeper shopkeeper;

    public override void PlayerArrived()
    {
        base.PlayerArrived();
        shopkeeper.Communicate();
    }
}
