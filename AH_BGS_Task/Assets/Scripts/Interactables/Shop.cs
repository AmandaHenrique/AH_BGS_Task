using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shop : Interactable
{
    [SerializeField] string sceneNameToLoad;
    Shopkeeper shopkeeper;
    private void Awake()
    {
        shopkeeper = GetComponentInChildren<Shopkeeper>();
    }
    public override void PlayerArrived()
    {
        base.PlayerArrived();
        shopkeeper.Communicate();
    }

    public override void StopInteraction()
    {
        base.StopInteraction();
        shopkeeper.StopCommunicate();
    }

    public override void SecondInteraction()
    {
        base.SecondInteraction();
        FadeScreen.Instance.FadeOut(LoadScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
