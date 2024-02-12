using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonDontDestroy<AudioManager>
{
    [SerializeField] AudioClip[] expressions;
    [SerializeField] AudioSource audioSourceSfx;

    public void PlayeExpression()
    {
        AudioClip audioClip = expressions[Random.Range(0, expressions.Length)];
        audioSourceSfx.PlayOneShot(audioClip);
    }
}
