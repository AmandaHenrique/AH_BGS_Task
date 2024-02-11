using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeScreen : Singleton<FadeScreen>
{
    [SerializeField] RectTransform circleFade;
    [SerializeField] bool fadeInAtStart;

    private void Start()
    {
        if (fadeInAtStart)
            FadeIn(null, 1);
    }

    public void FadeOut(Action callback = null, float delay = 0)
    {
        circleFade.DOSizeDelta(new Vector2(Screen.width * 3, Screen.height * 3), 0);
        circleFade.DOSizeDelta(new Vector2(0, 0), 1).SetDelay(delay).OnComplete(() => callback?.Invoke());
    }
    public void FadeIn(Action callback = null, float delay = 0)
    {
        circleFade.DOSizeDelta(new Vector2(0, 0), 0);
        circleFade.DOSizeDelta(new Vector2(Screen.width * 3, Screen.height * 3), 1).SetDelay(delay).OnComplete(() => callback?.Invoke());
    }
}
