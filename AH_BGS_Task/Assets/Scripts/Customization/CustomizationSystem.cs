using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationSystem : Singleton<CustomizationSystem>
{
    [SerializeField] CustomizationInfosSO customizationInfosSO;

    [Header("Renderers")]
    [SerializeField] SpriteRenderer head;
    [SerializeField] SpriteRenderer body;
    [SerializeField] SpriteRenderer sword;

    private void Start()
    {
        UpdateCharacter();
    }

    public void Customize(BodyPart bodyPart, Sprite sprite)
    {
        switch (bodyPart)
        {
            case BodyPart.Head:
                customizationInfosSO.head = sprite;
                break;
            case BodyPart.Body:
                customizationInfosSO.body = sprite;
                break;
            case BodyPart.Sword:
                customizationInfosSO.sword = sprite;
                break;
            default:
                break;
        }
        UpdateCharacter();
    }

    public void UpdateCharacter()
    {
        head.sprite = customizationInfosSO.head;
        body.sprite = customizationInfosSO.body;
        sword.sprite = customizationInfosSO.sword;
    }
}
