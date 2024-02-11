using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CommunicationTextsSO", menuName = "ScriptableObjects/CommunicationTextsSO")]
public class CommunicationTextsSO : ScriptableObject
{
    int currentText = 0;
    [TextArea] public string[] texts;

    public string GetText()
    {
        if (currentText >= texts.Length)
            currentText = 0;

        string text = texts[currentText];
        currentText++;
        if (currentText >= texts.Length)
            currentText = 0;
        return text;
    }
}
