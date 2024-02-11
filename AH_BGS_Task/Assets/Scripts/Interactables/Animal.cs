using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Interactable
{
    [SerializeField] Animator animator;

    public override void PlayerArrived()
    {
        base.PlayerArrived();
        animator.SetTrigger("Interact");
    }

    public override void SecondInteraction()
    {
        animator.SetTrigger("Interact");
    }
}
