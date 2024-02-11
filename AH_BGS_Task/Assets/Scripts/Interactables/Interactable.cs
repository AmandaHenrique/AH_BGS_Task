using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Transform posToStop;

    public virtual void Interact()
    {
        CharacterController.Instance.WalkTo(this);
    }
    public Transform PlayerPosToStop()
    {
        return posToStop;
    }

    public virtual void PlayerArrived()
    {
    }
    public virtual void SecondInteraction()
    {
    }
    public virtual void StopInteraction()
    {
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
        Interact();
    }
}
