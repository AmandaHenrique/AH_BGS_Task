using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponentInParent<CharacterController>();
    }

    public void EndAttack() {
        characterController.EndAttack();
    }
}
