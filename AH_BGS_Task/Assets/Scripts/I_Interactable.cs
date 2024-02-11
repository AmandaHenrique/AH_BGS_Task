using UnityEngine;

public interface I_Interactable
{
    public void Interact();
    public Transform PlayerPosToStop();
    public void PlayerArrived();
}
