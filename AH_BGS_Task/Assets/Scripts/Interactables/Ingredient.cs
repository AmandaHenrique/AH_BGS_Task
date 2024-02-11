using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Interactable
{
    public IngredientType ingredientType;
    bool canInteract = true;

    public override void PlayerArrived()
    {
        if (!canInteract) return;
        canInteract = false;
        base.PlayerArrived();
        CharacterController.Instance.Attack();
        InventorySystem.Instance.inventorySO.AddIngredient(ingredientType);
        Destroy(gameObject, 0.6f);
    }
}
