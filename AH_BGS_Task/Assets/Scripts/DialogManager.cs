using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DialogManager : Singleton<DialogManager>
{
    [SerializeField] Image icon;
    [SerializeField] Transform balloon;
    [SerializeField] TextMeshProUGUI nameTxt;
    [SerializeField] TextMeshProUGUI messageTxt;
    [SerializeField] CanvasGroup buttonsGroup;
    Interactable currentInteractable;

    public void ShowDialog(CharacterInfosSO characterInfosSO, string message, Interactable interactable) {
        currentInteractable = interactable;
        icon.sprite = characterInfosSO.icon;
        nameTxt.text = characterInfosSO.characterName;
        messageTxt.text = message;

        balloon.transform.DOScaleY(1, 0.3f).SetEase(Ease.OutBack);
        balloon.transform.DOScaleX(1, 0.3f).SetEase(Ease.OutBack).OnComplete(() => {
            icon.DOFade(1, 0.1f);
            nameTxt.DOFade(1, 0.1f);
            messageTxt.DOFade(1, 0.1f);

            buttonsGroup.DOFade(1, 0.1f).SetDelay(0.5f).OnComplete(() => {
                buttonsGroup.blocksRaycasts = true;
                buttonsGroup.interactable = true;
            });
        });
    }

    public void HideDialog()
    {
        icon.DOFade(0, 0.1f);
        nameTxt.DOFade(0, 0.1f);
        messageTxt.DOFade(0, 0.1f);
        buttonsGroup.blocksRaycasts = false;
        buttonsGroup.interactable = false;
        buttonsGroup.DOFade(0, 0.1f).OnComplete(() => {
            balloon.transform.DOScaleY(0, 0.3f).SetEase(Ease.InBack);
            balloon.transform.DOScaleX(0, 0.3f).SetEase(Ease.InBack);
        });

        if(currentInteractable != null)
            currentInteractable.StopInteraction();
    }

    public void Yes() {
        currentInteractable.SecondInteraction();
    }

    public void No() {
        HideDialog();
    }
}
