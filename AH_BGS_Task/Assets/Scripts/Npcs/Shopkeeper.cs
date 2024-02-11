using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Shopkeeper : MonoBehaviour
{
    [Header("References")]
    Interactable myInteractable;
    Animator animator;
    [SerializeField] CharacterInfosSO characterInfosSO;
    [SerializeField] CommunicationTextsSO communicationTextsSo;

    private void Awake()
    {
        myInteractable = GetComponentInParent<Interactable>();
        animator = GetComponentInChildren<Animator>();
    }
    public void Communicate() {
        animator.SetBool("Communicating", true);
        DialogManager.Instance.ShowDialog(characterInfosSO, communicationTextsSo.GetText(), myInteractable);
    }

    public void StopCommunicate()
    {
        animator.SetBool("Communicating", false);

    }
    private void OnMouseEnter()
    {
        CursorManager.Instance.SetCursor(CursorType.Pointer);
    }
    private void OnMouseExit()
    {
        CursorManager.Instance.SetCursor(CursorType.Normal);
    }

    private void OnMouseUpAsButton()
    {
        myInteractable.Interact();
    }
}
