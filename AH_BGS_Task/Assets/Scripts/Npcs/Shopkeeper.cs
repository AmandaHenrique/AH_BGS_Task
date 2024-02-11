using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Shopkeeper : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator;
    [SerializeField] CommunicationTextsSO communicationTextsSo;

    [Header("Dialog UI")]
    [SerializeField] Image dialogBaloon;
    [SerializeField] TextMeshProUGUI text;

    float timeToStopCommunicating = 10;
    Coroutine coroutine;

    public void Communicate() {
        animator.SetBool("Communicating", true);
        text.DOFade(0, 0);
        text.text = communicationTextsSo.GetText();

        dialogBaloon.transform.DOScale(1, 0.4f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(WaitToStopCommunication());
        });
        text.DOFade(1, 0.2f).SetDelay(0.3f);

    }

    IEnumerator WaitToStopCommunication() {

        yield return new WaitForSeconds(timeToStopCommunicating);
        StopCommunicate();
    }

    void StopCommunicate()
    {
        animator.SetBool("Communicating", false);
        dialogBaloon.transform.DOScale(0, 0.4f).SetEase(Ease.InBack);
        text.DOFade(0, 0.2f).SetDelay(0.1f);

    }
}
