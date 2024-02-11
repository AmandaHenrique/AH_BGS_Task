using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : Interactable
{
    bool canInteract = true;

    public override void PlayerArrived()
    {
        if (!canInteract) return;
        canInteract = false;
        base.PlayerArrived();
        Debug.Log("Take and animation");
        Destroy(gameObject, 1);
    }
}
